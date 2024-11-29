using Catalog.Service.Infrastructure.Http.EndpointHandlers;

namespace Catalog.Service.Infrastructure.Http.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void RegisterSongsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var songsEndpoints = endpointRouteBuilder
                .MapGroup("api/songs")
                .WithTags("Songs");

            songsEndpoints.MapGet("", SongsHandlers.GetSongsAsync)
                .WithName("GetSongs")
                .WithOpenApi();
        }

        public static void RegisterEndpoints(this IEndpointRouteBuilder app)
        {
            app.RegisterSongsEndpoints();
        }
    }
}
