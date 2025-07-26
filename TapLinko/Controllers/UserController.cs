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

        // Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {      
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(int id ,LinkPageUserVM vMs)
        {
            
            if (await _userService.IsUserNameTakenAsync(vMs.Name,id))
            {
                Console.WriteLine("Duplicated Name");
                return View(vMs);
            }
            if(ModelState.IsValid)
            {
                await _userService.Create(vMs);
                return RedirectToAction(nameof(Index));
            }

            return View(vMs);
        }

        // Detail - Read

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _userService.GetDetail(id);
            return View(product);
        }

        // Edit - Update
        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _userService.GetDetail(id);
            return View(product);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id,  LinkPageUserVM vMs)
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

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _userService.GetDetail(id);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id, LinkPageUserVM vMs)
        {
            var product = await _userService.Delete(id,vMs);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
