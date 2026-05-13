using GameStore.Data;
using GameStore.Dtos;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.EndPoints;

public static class GamesEndPoints
{
const string GetGameEndpointName = "GetName";
private static readonly List<GameSummaryDto> games = [
    new GameSummaryDto(1, "The Legend of Zelda: Breath of the Wild", "Action-adventure", 59.99m, new DateOnly(2017, 3, 3)),
    new GameSummaryDto(2, "Red Dead Redemption 2", "Action-adventure", 59.99m, new DateOnly(2018, 10, 26)),
    new GameSummaryDto(3, "The Witcher 3: Wild Hunt", "Action RPG", 39.99m, new DateOnly(2015, 5, 19)),
];

public static void MapGamesEndPoints(this WebApplication app)
    {
var group = app.MapGroup("/games");
     // GET /games
group.MapGet("/", async (GameStoreContext dbContext) => 
await dbContext.Games
.Include(game => game.Genre)
.Select(game => new GameSummaryDto(
    game.Id,
    game.Name,
    game.Genre!.Name,
    game.Price,
    game.ReleaseDate
))
.AsNoTracking()
.ToListAsync() );

// GET /games/{id}
group.MapGet("/{id}",async (int id, GameStoreContext dbContext) => {
var game = await dbContext.Games.FindAsync(id);
return game is null ? Results.NotFound() : Results.Ok(
new GameDetailsDto(
    game.Id,
    game.Name,
    game.GenreId,
    game.Price,
    game.ReleaseDate
) );
}).WithName(GetGameEndpointName); 


// POST /games
group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
{
   Game game = new Game
    {
        Name = newGame.Name,
        GenreId = newGame.GenreId,
        Price = newGame.Price,
        ReleaseDate = newGame.ReleaseDate
    };
    dbContext.Games.Add(game);
    await dbContext.SaveChangesAsync();

    GameDetailsDto gameDto = new (
        game.Id,
        game.Name,
        game.GenreId,
        game.Price,
        game.ReleaseDate
    );
    return Results.CreatedAtRoute(GetGameEndpointName, new { id = gameDto.Id }, gameDto);
});

// PUT /games/{id}
group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
{
    var Index = games.FindIndex(game => game.Id == id);
    if (Index == -1)
    {
        return Results.NotFound();
    }
    games[Index] = new GameSummaryDto(
        id,
        updatedGame.Name,
        updatedGame.Gender, 
        updatedGame.Price,
        updatedGame.ReleaseDate 
    );
    return Results.NoContent();
});

// DELETE /games/{id}
group.MapDelete("/{id}", (int id) =>
{
    games.RemoveAll(game => game.Id == id);
    return Results.NoContent();
});   
    }


}
