using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TapLinko.Data;
using TapLinko.Models;

namespace TapLinko.Controllers
{
    //Counting
    public class LinkRedirectController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public LinkRedirectController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Go(int id)
        {
            var linkItem = await _context.LinkItems.FindAsync(id);
            if (linkItem == null) return NotFound();

            // Update click count
            linkItem.ClickCount += 1;

            // Log click event
            var clickEvent = new ClickEvent
            {
                LinkItemId = linkItem.LinkItemId,
                Timestamp = DateOnly.FromDateTime(DateTime.UtcNow),
                Ip = HttpContext.Connection.RemoteIpAddress?.ToString(),
                UserAgent = Request.Headers["User-Agent"].ToString()
            };

            _context.ClickEvents.Add(clickEvent);
            await _context.SaveChangesAsync();

            return Redirect(linkItem.Url!);
        }
    }
}
