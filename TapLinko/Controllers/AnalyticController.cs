using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TapLinko.Data;
using TapLinko.Models;
using TapLinko.Models.ViewModel;

namespace TapLinko.Controllers
{
    [Authorize(Roles = "Supervisor")]

    public class AnalyticController : Controller
    {
        private ApplicationDbContext _context;
        public AnalyticController(ApplicationDbContext context)
        {
                _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var clickStats = await _context.ClickEvents
    .GroupBy(c => c.LinkItemId)
    .Select(g => new
    {
        LinkItemId = g.Key,
        ClickCount = g.Count()
    }).ToListAsync(); // <-- this executes and gets it into memory

            // Then get LinkItems and project into analytics model (in-memory join)
            var items = await _context.LinkItems
                .Select(l => new { l.LinkItemId, l.Label })
                .ToListAsync(); // materialize before combining

            // Now do the join in memory
            var data = items
                .Select(l => new LinkItemAnalyticsVM
                {
                    LinkItemId = l.LinkItemId,
                    Label = l.Label,
                    TotalClicks = clickStats.FirstOrDefault(cs => cs.LinkItemId == l.LinkItemId)?.ClickCount ?? 0
                })
                .ToList();

            var data2 = _context.ClickEvents.Select(c => new ClickEvent
            {
                Ip = c.Ip,
                UserAgent = c.UserAgent

            }).ToList();

            var viewmodel = new ViewModel
            {
                ClickEvents = data2,
                LinkItemAnalyticsVMs = data
            };

            
            return View(viewmodel);
        }
    }
}
