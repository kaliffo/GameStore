using GameStore.EndPoints;
using GameStore.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.AddGameStoreDb();

var app = builder.Build();

app.MapGamesEndPoints();
app.MapGenreEndPoints();

app.MigrateDb();

app.Run();
