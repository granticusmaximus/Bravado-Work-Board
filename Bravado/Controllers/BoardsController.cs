using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Bravado.Data;
using Bravado.Models;
using Bravado.Models.Agile;
using Bravado.ViewModel.BoardViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Bravado.Controllers
{
    [Authorize]
    public class BoardsController : Controller
    {
        private AppDbContext _context;

        private UserManager<ApplicationUser> _userManager;


        public BoardsController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        [HttpGet]
        public IActionResult All()
        {
            var Claims = this.User;
            ClaimsPrincipal currentUser = this.User;
            var uId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var Boards = _context.Boards.Where(board => board.UserId == uId).ToList();
            return View(Boards);
        }

        [HttpGet]
        public async Task<IActionResult> Open([FromRoute] Guid id)
        {
            var board = await _context.Boards.FindAsync(id);
            var t1 = await _context.Tasks.Where(task => task.BoardId == id.ToString()).Intersect(_context.Tasks.Where(task => task.ListNum == 1)).ToListAsync();
            var t2 = await _context.Tasks.Where(task => task.BoardId == id.ToString()).Intersect(_context.Tasks.Where(task => task.ListNum == 2)).ToListAsync();
            var t3 = await _context.Tasks.Where(task => task.BoardId == id.ToString()).Intersect(_context.Tasks.Where(task => task.ListNum == 3)).ToListAsync();

            return View(model: new BoardView { Board = board, TaskL1 = t1, TaskL2 = t2, TaskL3 = t3 });
        }

        [HttpGet]
        public IActionResult Add()
        {
            ClaimsPrincipal currentUser = this.User;
            var uId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View(new Board { UserId = uId });
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Board board)
        {

            _context.Boards.Add(board);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            var board = await _context.Boards.FindAsync(id);
            return View(board);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Board boardUpdate)
        {
            var board = await _context.Boards.FindAsync(boardUpdate.Id);

            board.Title = boardUpdate.Title;


            var routeValues = new RouteValueDictionary {
               {"id", board.Id.ToString()}
           };
            _context.Boards.Update(board);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Open), "Boards", routeValues);
        }

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var board = await _context.Boards.FindAsync(id);
            var tasks = await _context.Tasks.Where(task => task.BoardId == id.ToString()).ToListAsync();

            // Removes all tasks associated with the board
            foreach (Models.Agile.Task task in tasks)
            {
                _context.Tasks.Remove(task);
            }

            _context.Boards.Remove(board);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}