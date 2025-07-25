using Microsoft.AspNetCore.Mvc;
using TapLinko.Data;

namespace TapLinko.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
                _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //
            return View();
        }
    }
}
