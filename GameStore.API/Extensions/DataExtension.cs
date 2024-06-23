using GameStore.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Extensions
{
    public static class DataExtension
    {
        public static async Task MigrateDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await db.Database.MigrateAsync();
        }
    }
}
