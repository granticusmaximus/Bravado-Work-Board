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
        private readonly CardService _cardService;
        private BoardService _boardService;

        public AgileController(BoardService boardService, CardService cardService)
        {
            _boardService = boardService;
            _cardService = cardService;
        }
        
        public IActionResult Index()
        {
            var model = _boardService.ListBoard();

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateBoard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBoard(NewBoard viewModel)
        {
            _boardService.AddBoard(viewModel);
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult BoardDetail(int id)
        {
            var model = _boardService.GetBoard(id);

            return View(model);
        }

        public IActionResult Details(int id)
        {
            return View(_boardService.GetBoard(id));
        }

        public IActionResult DeleteCard(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteCard(CardDetails card)
        {
            _cardService.Delete(card.Id);
            return RedirectToAction(nameof(Index), new { id = card.Id });
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
            return RedirectToAction(nameof(BoardDetail), new { id = viewModel.Id });
        }

        [HttpGet]
        public IActionResult CardDetails(int id)
        {
            var viewModel = _cardService.GetDetails(id);

            return View(viewModel);
        }

        public IActionResult EditCard(int id)
        {
            return View(_cardService.GetDetails(id));
        }

        [HttpPost]
        public IActionResult CardUpdate(CardDetails cardDetails)
        {
            _cardService.Update(cardDetails);

            TempData["Message"] = "Saved card Details";

            return RedirectToAction(nameof(Details), new { id = cardDetails.Id });
        }
    }
}