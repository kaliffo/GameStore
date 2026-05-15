
using GameStore.Data;
using GameStore.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GameStore.EndPoints;

public static class GenreEndPoints
{
    public static void MapGenreEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("/genres");

        // GET /genres
        group.MapGet("/", async (GameStoreContext dbContext) =>
            await dbContext.Genres
                .Select(genre => new GenreDto(
                    genre.Id,
                    genre.Name
                ))
                .AsNoTracking()
                .ToListAsync()
        );
    }

}
