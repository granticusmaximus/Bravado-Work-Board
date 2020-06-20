﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Bravado.Data;
using Bravado.Models;
using Bravado.Models.BoardViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bravado.Controllers
{
    /// <summary>
    /// Controller for managing boards
    /// </summary>
    [Authorize]
    public class BoardsController : Controller
    {
        private AppDbContext _context;

        private UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Initializes the private value _context
        /// </summary>
        /// <param name="context">The context of the user</param>
        /// <param name="userManager">The authorization middleware</param>
        public BoardsController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        /// <summary>
        /// Gets all boards belonging to the currently logged in user
        /// </summary>
        /// <returns>The view of the users boards</returns>
        [HttpGet]
        public IActionResult All()
        {
            var Claims = this.User;
            ClaimsPrincipal currentUser = this.User;
            var uId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var Boards = _context.Boards.Where(board => board.UserId == uId).ToList();
            return View(Boards);
        }

        /// <summary>
        /// Opens a board
        /// </summary>
        /// <returns>View of board</returns>
        [HttpGet]
        public async Task<IActionResult> Open([FromRoute] Guid id)
        {
            var board = await _context.Boards.FindAsync(id);
            var t1 = await _context.Tasks.Where(task => task.BoardId == id.ToString()).Intersect(_context.Tasks.Where(task => task.ListNum == 1)).ToListAsync();
            var t2 = await _context.Tasks.Where(task => task.BoardId == id.ToString()).Intersect(_context.Tasks.Where(task => task.ListNum == 2)).ToListAsync();
            var t3 = await _context.Tasks.Where(task => task.BoardId == id.ToString()).Intersect(_context.Tasks.Where(task => task.ListNum == 3)).ToListAsync();

            return View(model: new BoardView { Board = board, TaskL1 = t1, TaskL2 = t2, TaskL3 = t3 });
        }

        /// <summary>
        /// Serves the add board page
        /// </summary>
        /// <returns>The view of the add board page</returns>
        [HttpGet]
        public IActionResult Add()
        {
            ClaimsPrincipal currentUser = this.User;
            var uId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View(new Board { UserId = uId });
        }

        /// <summary>
        /// Handles the creation of a new board
        /// </summary>
        /// <param name="board"> A board construct</param>
        /// <returns> A new board </returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Board board)
        {

            _context.Boards.Add(board);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        /// <summary>
        /// Returns the view to edit the board
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            var board = await _context.Boards.FindAsync(id);
            return View(board);
        }

        /// <summary>
        /// Returns the updated board  and saves the changes
        /// </summary>
        /// <param name="boardUpdate">The delta task</param>
        /// <returns></returns>
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

        /// <summary>
        /// The delete function for boards
        /// </summary>
        /// <param name="id">The id of the board to be deleted</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var board = await _context.Boards.FindAsync(id);
            var tasks = await _context.Tasks.Where(task => task.BoardId == id.ToString()).ToListAsync();

            // Removes all tasks associated with the board
            foreach (Models.Task task in tasks)
            {
                _context.Tasks.Remove(task);
            }

            _context.Boards.Remove(board);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        /// <summary>
        /// Handles error in production
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}