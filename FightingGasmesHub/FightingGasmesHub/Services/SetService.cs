using FightingGamesHub.Data;
using FightingGamesHub.Interfaces;
using FightingGamesHub.Models;

namespace FightingGamesHub.Services
{
    public class SetService : ISetService
    {
        private readonly FightingGamesHubContext _context;
        private readonly IPlayerService _playerService;
        private readonly IGameService _gameService;
        
        public SetService(FightingGamesHubContext context, IPlayerService playerService, IGameService gameService)
        {
            _context = context;
            _playerService = playerService;
            _gameService = gameService;
        }
        public int CreateSet(Set set)
        {
            if (!IsValidSet(set))
                return -1;
            _context.Sets.Add(set);
            return _context.SaveChanges();
        }

        private bool IsValidSet(Set set)
        {

            List<string> errorsMessage =  new List<string>();
            if (set.PlayerOneId == set.PlayerTwoId)
                errorsMessage.Add("Player 1 and Player 2 can't be the same.");
            if(set.MatchesToWin > set.SetMatches.Count)
                errorsMessage.Add($"There are at least {set.MatchesToWin - set.SetMatches.Count(x=> x.MatchWinnerPlayerId == set.SetMatches.GroupBy(m => m.MatchWinnerPlayerId).OrderByDescending(g => g.Count()).First().Key)} missing matches in this set.");
            else if (set.MatchesToWin < set.SetMatches.Count)
                errorsMessage.Add($"There are at least {set.SetMatches.Count(x => x.MatchWinnerPlayerId == set.SetMatches.GroupBy(m => m.MatchWinnerPlayerId).OrderByDescending(g => g.Count()).First().Key) - set.MatchesToWin} extra matches in this set.");
            if(!_playerService.DoesPlayerExists(set.PlayerOneId))
                errorsMessage.Add("Player 1 doesn't exists.");
            if (!_playerService.DoesPlayerExists(set.PlayerTwoId))
                errorsMessage.Add("Player 2 doesn't exists.");
            if(!_gameService.DoesGameExists(set.GameId))
                errorsMessage.Add($"Game doesn't exists.");
            if (set.IsTournament && set.TournamentId == null)
                errorsMessage.Add($"Need to specify the tournament.");
            if (set.IsLockedChararacters)
            {
                if(set.SetMatches.DistinctBy(x => x.PlayerOneCharacterId).Count() > 1)
                    errorsMessage.Add("Player 1 used more than character for a locked characters set.");
                if (set.SetMatches.DistinctBy(x => x.PlayerTwoCharacterId).Count() > 1)
                    errorsMessage.Add("Player 2 used more than character for a locked characters set.");
            }
            return !errorsMessage.Any();
        }
    }
}
