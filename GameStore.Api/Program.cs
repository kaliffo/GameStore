using GameStore.EndPoints;
using GameStore.Data;
using GameStore.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.AddGameStoreDb();

var app = builder.Build();

app.MapGamesEndPoints();

app.MigrateDb();

app.Run();
