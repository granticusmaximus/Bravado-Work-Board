﻿using System.Threading.Tasks;
using Bravado.Data;
using Bravado.Services;
using Bravado.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bravado.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        private readonly BoardService _boardService;
        private readonly AppDbContext _context;

        public BoardController(BoardService boardService, AppDbContext context)
        {
            _boardService = boardService;
            _context = context;
        }

        public IActionResult Home()
        {
            var model = _boardService.ListBoard();

            return View(model);
        }

        public IActionResult Index(int id)
        {
            var model = _boardService.GetBoard(id);

            return View(model);
        }

        public IActionResult Details(int id)
        {
            return View(_boardService.GetBoard(id));
        }

        public IActionResult AddCard(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCard(AddCard viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            _boardService.AddCard(viewModel);
            return RedirectToAction(nameof(Index), new { id = viewModel.Id });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewBoard viewModel)
        {
            _boardService.AddBoard(viewModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        // GET: Entry/Delete/5
        public IActionResult Delete()
        {
            return View();
        }

        // POST: Entry/Delete/5
        [HttpPost]
        public IActionResult Delete(CardDetails card)
        {
            _boardService.DeleteCard(card);
            return RedirectToAction(nameof(Index));
        }
    }
}