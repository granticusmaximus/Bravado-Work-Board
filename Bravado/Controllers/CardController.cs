using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bravado.Services;
using Bravado.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bravado.Controllers
{
    public class CardController : Controller
    {
        private readonly CardService _cardService;

        public CardController(CardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var viewModel = _cardService.GetDetails(id);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(CardDetails cardDetails)
        {
            _cardService.Update(cardDetails);

            TempData["Message"] = "Saved card Details";

            return RedirectToAction(nameof(Details), new { id = cardDetails.Id });
        }
    }
}
