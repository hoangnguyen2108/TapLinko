using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Runtime.InteropServices;
using TapLinko.Data;
using TapLinko.Models;
using TapLinko.Models.ViewModel;
using TapLinko.Services.LinkItem;

namespace TapLinko.Controllers
{
    [Authorize(Roles = "Supervisor")]
    public class LinkItemController : Controller
    {
        private ApplicationDbContext _context;
        private ILinkItemService _linkItemService;
        public LinkItemController(ILinkItemService linkItemService,ApplicationDbContext context)
        {
            _linkItemService = linkItemService;
            _context = context;
        }
        // Index
        public async Task<IActionResult> Index(int id)
        {
            
            var summary = await _linkItemService.Index(id);
            return View(summary);
        }

        // Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _linkItemService.GetDetail(id);      
            ViewBag.LinkPages = new SelectList(_context.LinkPages, "LinkPageId", "LinkPageTitle");
                 
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit (int id,LinkPageLinkItemVM vMs)
        {
            var product = await _linkItemService.Edit(id, vMs);
            return RedirectToAction(nameof(Index));

        }

        // Detail 
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _linkItemService.GetDetail(id);

            var linkPage = await _context.LinkPages.FindAsync(product.LinkPageId);
            ViewBag.LinkPageTitle = linkPage?.LinkPageTitle ?? "Unknown";
           
           

            return View(product);
        }
        // Create

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.LinkPages = new SelectList(_context.LinkPages, "LinkPageId", "LinkPageTitle");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult>Create (LinkPageLinkItemVM vMs)
        {


            var (success, errorMessage) = await _linkItemService.CreateAsync(vMs);

            if (!success)
            {
                ModelState.AddModelError("Order", errorMessage);
                ViewBag.LinkPages = new SelectList(_context.LinkPages, "LinkPageId", "LinkPageTitle");
                return View(vMs);
            }

            return RedirectToAction(nameof(Index));
        }


        // Delete

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _linkItemService.GetDetail(id);
            ViewBag.LinkPages = new SelectList(_context.LinkPages, "LinkPageId", "LinkPageTitle");
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id, LinkPageLinkItemVM vMs)
        {
            await _linkItemService.Delete(id, vMs);
            return RedirectToAction(nameof(Index));
        }


        
    }
}
