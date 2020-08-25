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
using Bravado.Services;
using Bravado.Repos;
using Microsoft.AspNetCore.Http;

namespace Bravado.Controllers
{
    [Authorize]
    public class AgileController : Controller
    {
        private readonly AppDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private IBoardRepo repo;
        private BoardService service;

        public AgileController(AppDbContext context, UserManager<ApplicationUser> userManager, IBoardRepo repo, BoardService service)
        {
            _context = context;
            _userManager = userManager;
            this.repo = repo;
            this.service = service;
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
        public async Task<IActionResult> NewBoard([FromForm] Board board)
        {

            _context.Boards.Add(board);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Open([FromRoute] int ID)
        {   
            var board = await _context.Boards.FindAsync(ID);
            var cardList = repo.GetCardList();
            var columnList = repo.GetColumnList(ID);
            return View(model: new BoardDetails { Board = board, Columns = columnList, Cards = cardList });
        }

        [HttpPost]
        public IActionResult AddCard(AddCard viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            service.AddCard(viewModel);
            return RedirectToAction(nameof(Open), new { id = viewModel.Id });
        }
        #endregion

    }
}