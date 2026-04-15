using GameStore.EndPoints;
using GameStore.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var connString = "Data source=GameStore.db";
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndPoints();

app.Run();
