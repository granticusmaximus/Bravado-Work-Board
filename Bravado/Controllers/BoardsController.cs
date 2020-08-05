using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Bravado.Data;
using Bravado.Models;
using Bravado.Models.Agile;
using Bravado.Services;
using Bravado.ViewModel.BoardViewModels;
using Bravado.ViewModel.TaskViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Bravado.Controllers {
    [Authorize]
    public class BoardsController : Controller {
        private readonly BoardService _boardService;

        public BoardsController (BoardService boardService) {
            _boardService = boardService;
        }

        public IActionResult Index (Guid id) {
            var model = _boardService.GetBoard (id);

            return View (model);
        }

        public IActionResult Details (Guid id) {
            return View (_boardService.GetBoard (id));
        }

        public IActionResult AddCard (int id) {
            return View ();
        }

        [HttpPost]
        public IActionResult AddCard (AddCard viewModel) {
            if (!ModelState.IsValid) return View (viewModel);
            _boardService.AddCard (viewModel);
            return RedirectToAction (nameof (Index), new { id = viewModel.Id });
        }
    }
}