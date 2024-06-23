using GameStore.API.Dtos;
using GameStore.Domain.Entities;

namespace GameStore.API.Extensions
{
    public static class MappingExtension
    {
        public static Game ToEntity(this CreateGameDto createGame)
        {
            return new Game() { Name = createGame.Name, GenreId = createGame.GenreId, Price = createGame.Price, ReleaseDate = createGame.ReleaseDate };
        }

        public static Game ToEntity(this UpdateGameDto createGame, int id)
        {
            return new Game() { Id = id, Name = createGame.Name, GenreId = createGame.GenreId, Price = createGame.Price, ReleaseDate = createGame.ReleaseDate };
        }

        public static GameSummaryDto ToGameSummaryDto(this Game newGame)
        {
            return new(newGame.Id, newGame.Name, newGame.Genre!.Name, newGame.Price, newGame.ReleaseDate);
        }

        public static GameDetailsDto ToGameDetailsDto(this Game newGame)
        {
            return new(newGame.Id, newGame.Name, newGame.GenreId, newGame.Price, newGame.ReleaseDate);
        }

        public static GenreDto ToDto(this Genre genre)
        {
            return new GenreDto(genre.Id, genre.Name);
        }
    }
}
