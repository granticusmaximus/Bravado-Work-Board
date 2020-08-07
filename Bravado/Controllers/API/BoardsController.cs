using Bravado.Services;
using Bravado.ViewModel.TaskViewModels;

using Microsoft.AspNetCore.Mvc;
namespace Bravado.Controllers.API {
    [Route ("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase {
        private readonly BoardService _boardService;
        public BoardsController (BoardService boardService) {
            _boardService = boardService;
        }

        [HttpPost ("movecard")]
        public IActionResult MoveCard ([FromBody] MoveCardCommand command) {
            return Ok (new {
                Moved = true
            });
        }
    }
}