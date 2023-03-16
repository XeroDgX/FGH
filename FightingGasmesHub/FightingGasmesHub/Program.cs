using FightingGamesHub.Data;
using FightingGamesHub.Interfaces;
using FightingGamesHub.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<ISetService, SetService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddDbContext<FightingGamesHubContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("FightingGamesHubDatabase")));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
