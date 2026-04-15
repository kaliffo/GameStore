using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos;

public record UpdateGameDto
(
    [Required] [StringLength(50)] string Name,
    [Required] [StringLength(20)] string  Gender,
    [Range(0, 100)] decimal Price,
    DateOnly ReleaseDate = new DateOnly()  
);
