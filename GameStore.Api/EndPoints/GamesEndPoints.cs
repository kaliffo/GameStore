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
group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
{
    var exsitingGame = await dbContext.Games.FindAsync(id);
    if (exsitingGame is null)
    {
        return Results.NotFound();
    }
    exsitingGame.Name = updatedGame.Name;
    exsitingGame.GenreId = updatedGame.GenreId;
    exsitingGame.Price = updatedGame.Price;
    exsitingGame.ReleaseDate = updatedGame.ReleaseDate;

    await dbContext.SaveChangesAsync();
    return Results.NoContent();
});
    
    // DELETE /games/{id}
group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
{
    var gameToDelete = dbContext.Games.Find(id);
    if (gameToDelete is null)
    {
        return Results.NotFound();
    }
    dbContext.Games.Remove(gameToDelete);
    await dbContext.SaveChangesAsync();
    return Results.NoContent();
});   
    }


}
