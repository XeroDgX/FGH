using FightingGamesHub.Data;
using FightingGamesHub.Interfaces;
using FightingGamesHub.Models;

namespace FightingGamesHub.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly FightingGamesHubContext _context;

        public CharacterService(FightingGamesHubContext context)
        {
            _context = context;
        }
        public List<Character> GetAllCharacters()
        {
            return _context.Characters.ToList();
        }

        public Character? GetCharacterById(int id)
        {
            return _context.Characters.FirstOrDefault(x => x.Id == id);
        }

        public List<Character> GetCharactersByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
