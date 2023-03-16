using FightingGamesHub.Data;
using FightingGamesHub.Interfaces;

namespace FightingGamesHub.Services
{
    public class GameCharacterService : IGameCharacterService
    {
        private readonly FightingGamesHubContext _context;
        public bool DoesCharacterGameExists(int characterId)
        {
            return _context.GameCharacters.Any(x=> x.CharacterId == characterId);
        }
    }
}
