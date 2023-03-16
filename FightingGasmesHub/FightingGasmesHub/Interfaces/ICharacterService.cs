using FightingGamesHub.Models;

namespace FightingGamesHub.Interfaces
{
    public interface ICharacterService
    {
        public Character? GetCharacterById(int id);
        public List<Character> GetAllCharacters();
        public List<Character> GetCharactersByName(string name);
    }
}
