using GameStore.API.Dtos;
using GameStore.API.Extensions;
using GameStore.DataAccess.Data;
using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Endpoints
{
    public static class GameEndpoints
    {
        public static RouteGroupBuilder MapGameEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("games").WithParameterValidation();
            // GET /games
            group.MapGet("/", async (ApplicationDbContext context) =>
                await context.Games.Include(game => game.Genre)
                    .Select(game => game.ToGameSummaryDto()).AsNoTracking().ToListAsync()
            );

            // GET /games/id
            group.MapGet("/{id}", async (int id, ApplicationDbContext context) =>
            {
                Game? game = await context.Games.FindAsync(id);
                return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
            })
                .WithName("GetGameById");

            // POST /games
            group.MapPost("/", async (CreateGameDto createGame, ApplicationDbContext context) =>
            {
                //using var stream = File.OpenWrite(file.FileName);
                //await file.CopyToAsync(stream);
                Game newGame = createGame.ToEntity();
                newGame.Genre = context.Genres.Find(createGame.GenreId);
                
                context.Games.Add(newGame);
                await context.SaveChangesAsync();

                return Results.CreatedAtRoute("GetGameById", new { id = newGame.Id }, newGame.ToGameDetailsDto());
            });

            // PUT /games/id
            group.MapPut("/{id}", async (int id, UpdateGameDto updateGame, ApplicationDbContext context) =>
            {
                var editGame = await context.Games.FindAsync(id);
                if (editGame == null)
                {
                    return Results.NotFound();
                }

                context.Entry(editGame).CurrentValues.SetValues(updateGame.ToEntity(id));
                await context.SaveChangesAsync();

                return Results.NoContent();
            });

            // DELETE /games/id
            group.MapDelete("/{id}", async (int id, ApplicationDbContext context) =>
            {
                await context.Games.Where(game => game.Id == id).ExecuteDeleteAsync();
                return Results.NoContent();
            });

            return group;
        }
    }
}
