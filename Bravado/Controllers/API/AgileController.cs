using Bravado.Services;
using Bravado.ViewModel.AgileViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bravado.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgileController : ControllerBase
    {
        private readonly BoardService _boardService;
        public AgileController(BoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpPost("movecard")]
        public IActionResult MoveCard([FromBody] MoveCardCommand command)
        {
            return Ok(new
            {
                Moved = true
            });
        }
    }
}