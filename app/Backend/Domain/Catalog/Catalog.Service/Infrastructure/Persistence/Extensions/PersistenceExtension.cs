using Catalog.Service.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Service.Infrastructure.Persistence.Extensions
{
    public class PersistenceOptions
    {
        public string ConnectionString { get; set; }        
    }

    public static class PersistenceExtension
    {
        public static void UseSeedData(this IHost app)
        {
            var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopedFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<CatalogContext>();
                context.EnsureSeedDataForContext();
            }
        }
        public static void AddPersistence(this IServiceCollection services, Action<PersistenceOptions> configure)
        {
            var options = new PersistenceOptions();
            configure(options);

            services.AddDbContext<CatalogContext>(o => o.UseSqlServer(options.ConnectionString));
        }
    }
}
