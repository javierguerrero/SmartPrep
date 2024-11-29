using Catalog.Service.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Service.Infrastructure.Http.EndpointHandlers
{
    public class SongsHandlers
    {
        public static async Task<IResult> GetSongsAsync([FromServices] ICatalogApplicationService _catalogApplicationService)
        {
            var songs = await _catalogApplicationService.GetSongsAsync();
            return TypedResults.Ok(songs); 
        }
    }
}
