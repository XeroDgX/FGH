using FightingGamesHub.Data;
using FightingGamesHub.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FightingGamesHub.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;
        public GamesController(IGameService gameService) 
        { 
            _gameService = gameService;
        }
        [HttpGet]
        public IActionResult GetGameById(int id)
        {
            var result = _gameService.GetGameById(id);
            if(result == null)
                return NotFound($"Game with id {id} doesn't exists.");
            return Ok(result);
        }
    }
}
