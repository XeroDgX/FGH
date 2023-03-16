using FightingGamesHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace FightingGamesHub.Interfaces
{
    public interface IGameService
    {

        public Game? GetGameById(int id);
        public List<Game> GetAllActiveGames();
        public List<Game> GetAllGames();
        public List<Game> GetGameByName();
        public bool DoesGameExists (int id);
    }
}
