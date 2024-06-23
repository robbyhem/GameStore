using GameStore.API.Extensions;
using GameStore.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Endpoints
{
    public static class GenreEndpoints
    {
        public static RouteGroupBuilder MapGenreEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("genres");
            // GET /genres
            group.MapGet("/", async (ApplicationDbContext context) =>
                await context.Genres.Select(genre => genre.ToDto()).AsNoTracking().ToListAsync());

            return group;
        }
    }
}
