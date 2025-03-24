using Mhung.Data;
using Microsoft.EntityFrameworkCore;

namespace Mhung.Api
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope()){
                using (var context = scope.ServiceProvider.GetRequiredService<MhungBlogContext>())
                {
                    context.Database.Migrate();
                    new DataSeeDer().SeedAsync(context).Wait();
                }
            };
           
            return app;
        }

    }
}
