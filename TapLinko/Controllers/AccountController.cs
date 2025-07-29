using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                Bio = "Welcome to my link page!",
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

    public async Task<IActionResult> Detail(int id)
    {
        var product = await _context.LinkPages.FirstOrDefaultAsync(c => c.LinkPageId == id);
        if (product == null)
        {
            return NotFound();
        }

        var model = new LinkPageLinkItemVM
        {
            LinkPageTitle = product.LinkPageTitle,
            Bio = product.Bio,
            ProfileImageUrl = product.ProfileImageUrl
        };


        return View(model);
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
}