using System;

using Bravado.Services;
using Bravado.ViewModel.TaskViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bravado.Controllers {

    [Authorize]
    public class CardController : Controller {
        private readonly CardService _cardService;

        public CardController (CardService cardService) {
            _cardService = cardService;
        }

        [HttpGet]
        public IActionResult Details (Guid id) {
            var viewModel = _cardService.GetDetails (id);

            return View (viewModel);
        }

        [HttpPost]
        public IActionResult Update (CardDetails cardDetails) {
            _cardService.Update (cardDetails);

            TempData ["Message"] = "Saved card Details";

            return RedirectToAction (nameof (Details), new { id = cardDetails.Id });
        }
    }
}