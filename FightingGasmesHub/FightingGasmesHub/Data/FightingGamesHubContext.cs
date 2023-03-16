using FightingGamesHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FightingGamesHub.Data
{
    public class FightingGamesHubContext: DbContext
    {
        protected readonly IConfiguration _configuration;

        public FightingGamesHubContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("FightingGamesHubDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Game>()
                .HasKey(g => g.Id)
                .HasName("Games");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Game> Games { get; set;}
        public DbSet<Character> Characters { get; set;}
        public DbSet<Player> Players { get; set;}
        public DbSet<SetMatch> SetMatches { get; set;}
        public DbSet<Set> Sets { get; set;}
        public DbSet<GameCharacter> GameCharacters { get; set;}


    }
}
