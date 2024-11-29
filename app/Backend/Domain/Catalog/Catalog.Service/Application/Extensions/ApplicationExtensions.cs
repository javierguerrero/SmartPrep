using Catalog.Service.Application.Interfaces;
using Catalog.Service.Application.Mappers;
using Catalog.Service.Application.Services;

namespace Catalog.Service.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(SongMapper));
            services.AddScoped<ICatalogApplicationService, CatalogApplicationService>();
        }
    }
}
