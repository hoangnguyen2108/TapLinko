using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TapLinko.Models;
using TapLinko.Models.ViewModel;


public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    // Index
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
            return RedirectToPage("/Account/Login", new { area = "Identity" });

        // Find or create user's LinkPage
        var linkPage = await _context.LinkPages
            .FirstOrDefaultAsync(lp => lp.UserId == user.Id);

        if (linkPage == null)
        {
            linkPage = new LinkPage
            {
                UserId = user.Id,
                LinkPageTitle = $"{user.FirstName} {user.LastName}'s Page",
                Bio = "Welcome To My Link Page!",
                ProfileImageUrl = "/image/image.jpeg",
                BannerImageUrl = "/image/image.jpeg"
            };

            _context.LinkPages.Add(linkPage);
            await _context.SaveChangesAsync();
        }

        // Get all LinkItems belonging to this page
        var linkPageLinkItemVMs = await _context.LinkItems
            .Where(c => c.LinkPageId == linkPage.LinkPageId)
            .Select(c => new LinkPageLinkItemVM
            {
                LinkItemId = c.LinkItemId,
                Label = c.Label,
                Url = c.Url,
                Order = c.Order
            })
            .ToListAsync();

        var viewModel = new ViewModel
        {
            LinkPages = new List<LinkPage> { linkPage },
            LinkPageLinkItemVMs = linkPageLinkItemVMs
        };

        return View(viewModel);
    }

    // Detail

    [HttpGet("/view/{slug}")]
    public async Task<IActionResult> Detail(string slug)
    {
        var linkPage = await _context.LinkPages
        .FirstOrDefaultAsync(lp => lp.PublicSlug == slug);

        if (linkPage == null)
        {
            return NotFound();
        }

        var model = new LinkPageLinkItemVM
        {
            LinkPageTitle = linkPage.LinkPageTitle,
            Bio = linkPage.Bio,
            ProfileImageUrl = linkPage.ProfileImageUrl
        };

        var linkItems = await _context.LinkItems
            .Where(c => c.LinkPageId == linkPage.LinkPageId)
            .Select(c => new LinkPageLinkItemVM
            {
                LinkItemId = c.LinkItemId,
                Label = c.Label,
                Url = c.Url,
                Order = c.Order
            })
            .ToListAsync();

        var viewModel = new ViewModel
        {
            LinkPageLinkItemVMs = new List<LinkPageLinkItemVM> { model },
            LinkPageLinkItemVMs1 = linkItems
        };

        return View(viewModel);
    }

    // Create Link Item
    [HttpGet]
    public async Task<IActionResult> Create(int id)
    {
        var maxOrder = await _context.LinkItems
     .Where(c => c.LinkPageId == id)
     .MaxAsync(c => (int?)c.Order) ?? 0;
        var vm = new LinkPageLinkItemVM
        {
            LinkPageId = id,
            MaxOrder = maxOrder
        };

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(int id, LinkPageLinkItemVM vMs)
    {
        var linkPage = await _context.LinkPages.FindAsync(id);
        if (linkPage == null)
        {
            return NotFound();
        }

        var itemCount = await _context.LinkItems
            .Where(c => c.LinkPageId == id)
            .CountAsync();

        if (itemCount >= 4)
        {
            ModelState.AddModelError("", "You can only create up to 4 link items per page.");
            return View(vMs);
        }

        if (vMs.Order <= 0 || vMs.Order > itemCount + 1)
        {
            ModelState.AddModelError("Order", $"Order must be between 1 and {itemCount + 1}.");
            return View(vMs);
        }

        if (!ModelState.IsValid)
        {
            return View(vMs);
        }

        // ⚠️ Use transaction to prevent race conditions or partial updates
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            // Shift items with equal or higher order
            var itemsToShift = await _context.LinkItems
                .Where(c => c.LinkPageId == id && c.Order >= vMs.Order)
                .ToListAsync();

            foreach (var item in itemsToShift)
            {
                item.Order += 1;
            }

            _context.LinkItems.UpdateRange(itemsToShift);

            // Add the new item
            var newItem = new LinkItem
            {
                Label = vMs.Label,
                Url = vMs.Url,
                Order = vMs.Order,
                LinkPageId = id
            };

            _context.LinkItems.Add(newItem);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return RedirectToAction("Index", "Account", new { id = id });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            ModelState.AddModelError("", "An error occurred while creating the link item.");
            Console.WriteLine(ex.Message);
            return View(vMs);
        }

        
    }
    // Edit 
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _context.LinkItems.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        var linkPageId = product.LinkPageId;

        var maxOrder = await _context.LinkItems
            .Where(c => c.LinkPageId == linkPageId)
            .MaxAsync(c => (int?)c.Order) ?? 0;

        var model = new LinkPageLinkItemVM
        {
            LinkItemId = product.LinkItemId,
            Label = product.Label,
            Url = product.Url,
            Order = product.Order,
            MaxOrder = maxOrder
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, LinkPageLinkItemVM vMs)
    {
        var item = await _context.LinkItems.FindAsync(id);
        if (item == null) return NotFound();

        var linkPageId = item.LinkPageId;

        // Validate new order
        var totalItems = await _context.LinkItems
            .Where(c => c.LinkPageId == linkPageId)
            .CountAsync();

        if (vMs.Order <= 0 || vMs.Order > totalItems)
        {
            ModelState.AddModelError("Order", $"Order must be between 1 and {totalItems}");
            return View(vMs);
        }

        // If the order is changing, update others
        if (item.Order != vMs.Order)
        {
            var direction = vMs.Order > item.Order ? -1 : 1;

            var itemsToShift = await _context.LinkItems
                .Where(c => c.LinkPageId == linkPageId
                            && c.LinkItemId != id
                            && c.Order >= Math.Min(item.Order, vMs.Order)
                            && c.Order <= Math.Max(item.Order, vMs.Order))
                .ToListAsync();

            foreach (var shift in itemsToShift)
            {
                shift.Order += direction;
            }

            _context.LinkItems.UpdateRange(itemsToShift);
        }

        item.Label = vMs.Label;
        item.Url = vMs.Url;
        item.Order = vMs.Order;

        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Account", new { id = id });
    }
    // Delete 
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.LinkItems.FindAsync(id);

        if(product == null)
        {
            return NotFound();
        }

        var model = new LinkPageLinkItemVM
        {

            Label = product.Label,
            Url = product.Url,
            Order = product.Order,
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id,LinkPage vm)
    {
        var item = await _context.LinkItems.FindAsync(id);
        if (item == null) return NotFound();

        var itemsToShift = await _context.LinkItems
            .Where(c => c.LinkPageId == item.LinkPageId && c.Order > item.Order)
            .ToListAsync();

        foreach (var shiftItem in itemsToShift)
            shiftItem.Order -= 1;

        _context.LinkItems.Remove(item);
        _context.LinkItems.UpdateRange(itemsToShift);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}