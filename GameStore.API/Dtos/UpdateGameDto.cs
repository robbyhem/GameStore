using System.ComponentModel.DataAnnotations;

namespace GameStore.API.Dtos
{
    public record UpdateGameDto(
        [Required, StringLength(30)] string Name, 
        int GenreId, 
        [Range(1, 10000)] decimal Price, 
        DateTime ReleaseDate
    );
}
