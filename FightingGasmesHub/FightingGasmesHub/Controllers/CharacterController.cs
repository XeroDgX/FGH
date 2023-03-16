using FightingGamesHub.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FightingGamesHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : Controller
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService) 
        {
            _characterService = characterService;
        }

        [HttpGet("characters/{id}")] 
        public IActionResult GetCharacterById(int id) 
        {
            var result = _characterService.GetCharacterById(id);
            if(result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("characters")]
        public IActionResult GetAllCharacters()
        {
            var result = _characterService.GetAllCharacters();
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
