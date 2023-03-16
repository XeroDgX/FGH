using FightingGamesHub.Interfaces;
using FightingGamesHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace FightingGamesHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetController : Controller
    {
        private readonly ISetService _setService;
        public SetController(ISetService setService) 
        { 
            _setService = setService; 
        }

        [HttpPost("Create")]
        public int CreateSet([FromBody] Set set) 
        { 
            return _setService.CreateSet(set);
        }
    }
}
