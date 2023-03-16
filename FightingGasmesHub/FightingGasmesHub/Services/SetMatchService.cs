using FightingGamesHub.Data;
using FightingGamesHub.Interfaces;
using FightingGamesHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FightingGamesHub.Services
{
    public class SetMatchService : ISetMatchService
    {
        private readonly FightingGamesHubContext _context;
        private readonly IGameCharacterService _gameCharacterService;

        public SetMatchService(FightingGamesHubContext context, IGameCharacterService gameCharacterService)
        {
            _context = context;
            _gameCharacterService = gameCharacterService;
        }

        public int CreateSetMatch(SetMatch setMatch)
        {
            if(!IsValidSetMatch(setMatch)) 
                return -1;
            _context.SetMatches.Add(setMatch);
            return _context.SaveChanges();
        }

        private bool IsValidSetMatch(SetMatch setMatch)
        {
            List<string> errorsMessage = new List<string>();
            if (_gameCharacterService.DoesCharacterGameExists(setMatch.PlayerOneCharacterId))
                errorsMessage.Add("Player 1 character doesn't exists.");
            if (_gameCharacterService.DoesCharacterGameExists(setMatch.PlayerTwoCharacterId))
                errorsMessage.Add("Player 2 character doesn't exists.");
            return !errorsMessage.Any();
        }

    }
}
