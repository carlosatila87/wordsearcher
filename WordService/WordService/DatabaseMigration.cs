using Microsoft.EntityFrameworkCore;

namespace WordService
{
    public static class DatabaseMigration
    {
        public static IHost MigrateDatabase<T>(this IHost host) where T : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<T>();
                dbContext.Database.Migrate();
            }

            return host;
        }
    }
}
