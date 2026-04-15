using System;

namespace GameStore.Models;

public class Game
{
    public int Id { get; set; }
    public required string Name { get; set; } 
    public Genre? Genre { get; set; }    // Navigation property to Genre
    public int GenreId { get; set; } // Foreign key to Genre
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
