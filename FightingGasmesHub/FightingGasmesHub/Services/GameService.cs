using FightingGamesHub.Data;
using FightingGamesHub.Interfaces;
using FightingGamesHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FightingGamesHub.Services
{
    public class GameService: IGameService
    {
        private readonly FightingGamesHubContext _context;
        public GameService(FightingGamesHubContext context) 
        {
            _context = context;
        }

        public bool DoesGameExists(int id)
        {
            return _context.Games.Any(x => x.Id == id);
        }

        public List<Game> GetAllActiveGames()
        {
            throw new NotImplementedException();
        }

        public List<Game> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public Game? GetGameById(int id)
        {
            return _context.Games.FirstOrDefault(x => x.Id == id && x.IsActive);
           
        }

        public List<Game> GetGameByName()
        {
            throw new NotImplementedException();
        }
    }
}
