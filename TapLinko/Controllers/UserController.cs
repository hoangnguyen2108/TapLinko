using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TapLinko.Data;
using TapLinko.Models;
using TapLinko.Models.ViewModel;
using TapLinko.Services;

namespace TapLinko.Controllers
{
    [Authorize(Roles = "Supervisor")]
    public class UserController : Controller
    {
        private ApplicationDbContext _context;
        private ILinkPageUserService _userService;
        public UserController(ILinkPageUserService userService,ApplicationDbContext context)
        {
            _userService = userService;
                _context = context;
        }
        // check duplicate name
         
        // View
        public async Task<IActionResult> Index()
        {
            // Summary User
            var summaryUser = await _userService.Index();   
            return View(summaryUser);
        }

       

        // Detail - Read

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var product = await _userService.GetDetail(id);
            return View(product);
        }

        // Edit - Update
        [HttpGet]

        public async Task<IActionResult> Edit(string id)
        {
            var product = await _userService.GetDetail(id);
            return View(product);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(string id,  LinkPageUserVM vMs)
        {
            

            if (await _userService.IsUserNameTakenAsync(vMs.Name,id))
            {
                return null;
            }

            await _userService.Edit(id, vMs);
            return RedirectToAction(nameof(Index));
        }


        // Delete

        [HttpGet]

        public async Task<IActionResult> Delete(string id)
        {
            var product = await _userService.GetDetail(id);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(string id, LinkPageUserVM vMs)
        {
            var product = await _userService.Delete(id,vMs);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
