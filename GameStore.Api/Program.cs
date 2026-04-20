using GameStore.EndPoints;
using GameStore.Data;
using GameStore.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var connString = "Data source=GameStore.db";
builder.Services.AddSqlite<GameStoreContext>(connString,
optionsAction: options => options.UseSeeding((context, _) =>
{
    if (!context.Set<Genre>().Any())
    {
        context.Set<Genre>().AddRange(
            new Genre { Name = "Action" },
            new Genre { Name = "Adventure" },
            new Genre { Name = "RPG" },
            new Genre { Name = "Strategy" },
            new Genre { Name = "Sports" },
            new Genre { Name = "Racing" },
            new Genre { Name = "Fighting" }
        );
        context.SaveChanges();
    }
})
);

var app = builder.Build();

app.MapGamesEndPoints();

app.MigrateDb();

app.Run();
