using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TapLinko.Models;
using TapLinko.Models.ViewModel;

[Authorize]
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
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return RedirectToPage("/Account/Login", new { area = "Identity" });

        var linkPage = await _context.LinkPages
            .FirstOrDefaultAsync(lp => lp.UserId == user.Id);

        // Auto-create if it doesn't exist
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

        return View(linkPage); // ✅ pass the LinkPage to the view
    }

    // Detail

    public async Task<IActionResult> Detail (string id)
    {
        var product = await _context.LinkPages.FindAsync(id);
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

        var modelLinkItem = new LinkPageLinkItemVM
        {

        };
        return View();
    }
}