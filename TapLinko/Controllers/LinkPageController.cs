using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TapLinko.Data;
using TapLinko.Models;
using TapLinko.Models.ViewModel;
using TapLinko.Services;

namespace TapLinko.Controllers
{
    [Authorize(Roles = "Supervisor")]
    public class LinkPageController : Controller
    {
        private ApplicationDbContext _context;
        private ILinkPageService _linkPageService;
        public LinkPageController(ILinkPageService linkPageService,ApplicationDbContext context)
        {
                _linkPageService = linkPageService;
                _context = context;
        }

        // Index
        public async Task<IActionResult> Index()
        {
            // List of Link
            var list = await _linkPageService.Index();

            return View(list);
        }

        // Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var users = await _context.Users
       .Select(u => new { u.Id, u.UserName })
       .ToListAsync();

            ViewBag.Users = new SelectList(users, "Id", "UserName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(LinkPageUserVM vMs)
        {
            if (await _linkPageService.IsDuplicateLinkPageAsync(vMs))
            {
                return View(vMs);
            }
            if(ModelState.IsValid)
            {
                await _linkPageService.Create(vMs);
                return RedirectToAction(nameof(Index));
            }
            var users = await _context.Users
       .Select(u => new { u.Id, u.UserName })
       .ToListAsync();
            ViewBag.Users = new SelectList(users, "Id", "UserName");

            return View(vMs);
        }

        // Detail 
        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var product = await _linkPageService.GetDetail(id);        
            return View(product);          
        }


        // Edit 

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var product = await _linkPageService.GetDetail(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(string id, LinkPageUserVM vMs)
        {
            if(await _linkPageService.IsDuplicateLinkPageAsync(vMs))
            {
                return View(vMs);
            }
            
            await _linkPageService.Edit(id,vMs);

            return RedirectToAction(nameof(Index));
            
        }

        // Delete

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _linkPageService.GetDetail(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, LinkPageUserVM vMs)
        {
            await _linkPageService.Delete(id,vMs);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
