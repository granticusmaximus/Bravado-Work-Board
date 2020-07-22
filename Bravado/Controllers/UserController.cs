
using System.Threading.Tasks;
using Bravado.Data;
using Bravado.Models;
using Bravado.ViewModel.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bravado.Controllers
{
    public class UserController : Controller
    {
        private AppDbContext _context;

        private UserManager<ApplicationUser> _userManager;

        public UserController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromForm] NewAppUser newAppUser)
        {

            var appUser = new ApplicationUser
            {

                UserName = newAppUser.UserName,
                Email = newAppUser.Email
            };
            await _userManager.CreateAsync(appUser, newAppUser.Password);

            return RedirectToAction("Login", "Account");
        }
    }
}