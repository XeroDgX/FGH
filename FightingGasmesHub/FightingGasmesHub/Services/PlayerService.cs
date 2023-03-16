using FightingGamesHub.Data;
using FightingGamesHub.Interfaces;

namespace FightingGamesHub.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly FightingGamesHubContext _context;
        public PlayerService(FightingGamesHubContext context) 
        { 
            _context = context;
        }

        public bool DoesPlayerExists(int id)
        {
            return _context.Players.Any(p => p.Id == id);
        }
    }
}
