using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bravado.Data;
using Bravado.Models.Agile;
using Microsoft.AspNetCore.Authorization;
using System;
using Bravado.ViewModel.AgileViewModels;
using Microsoft.AspNetCore.Identity;
using Bravado.Models;
using System.Security.Claims;

namespace Bravado.Controllers
{
    [Authorize]
    public class AgileController : Controller
    {
        private readonly AppDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public AgileController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        #region BOARD REGION
        [HttpGet]
        public IActionResult Index()
        {
            var Claims = this.User;
            ClaimsPrincipal currentUser = this.User;
            var uId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var Boards = _context.Boards.Where(board => board.UserId == uId).ToList();
            return View(Boards);
        }

        [HttpGet]
        public IActionResult NewBoard()
        {
            ClaimsPrincipal currentUser = this.User;
            var uId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View(new Board { UserId = uId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewBoard([Bind("BoardID,BoardTitle")] Board board)
        {
            _context.Boards.Add(board);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> OpenBoard(int ID)
        {   
            var board = await _context.Boards.FindAsync(ID);
            return View(model: new OpenBoardViewModel { Board = board });
        }

        [HttpPost]
        public async Task<IActionResult> AddColumn([FromForm] Column column)
        {

            _context.Columns.Add(column);
            await _context.SaveChangesAsync();
            return View();
        }
        #endregion

    }
}