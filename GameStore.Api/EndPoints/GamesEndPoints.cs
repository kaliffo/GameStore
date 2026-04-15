using GameStore.Dtos;

namespace GameStore.EndPoints;

public static class GamesEndPoints
{
const string GetGameEndpointName = "GetName";
private static readonly List<GameDto> games = [
    new GameDto(1, "The Legend of Zelda: Breath of the Wild", "Action-adventure", 59.99m, new DateOnly(2017, 3, 3)),
    new GameDto(2, "Red Dead Redemption 2", "Action-adventure", 59.99m, new DateOnly(2018, 10, 26)),
    new GameDto(3, "The Witcher 3: Wild Hunt", "Action RPG", 39.99m, new DateOnly(2015, 5, 19)),
];

public static void MapGamesEndPoints(this WebApplication app)
    {
var group = app.MapGroup("/games");
     // GET /games
group.MapGet("/", () => games);

// GET /games/{id}
group.MapGet("/{id}", (int id) => {
var game = games.Find(game => game.Id == id);
return game is null ? Results.NotFound() : Results.Ok(game) ;
}).WithName(GetGameEndpointName); 


// POST /games
group.MapPost("/", (CreateGameDto newGame) =>
{
    GameDto game = new GameDto(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);
    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});

// PUT /games/{id}
group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
{
    var Index = games.FindIndex(game => game.Id == id);
    if (Index == -1)
    {
        return Results.NotFound();
    }
    games[Index] = new GameDto(
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
