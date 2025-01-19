using Catalog.Service.Application.Dtos;
using Catalog.Service.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Catalog.Service.Infrastructure.Http.EndpointHandlers
{
    public class SongsHandlers
    {
        public static async Task<Results<BadRequest, Ok<List<SongDto>>>> GetSongsAsync(
            [FromServices] ICatalogApplicationService _catalogApplicationService
        )
        {
            var result = await _catalogApplicationService.GetSongsAsync();
            return TypedResults.Ok(result);
        }

        public static async Task<Results<BadRequest, Ok<SongDto>>> GetSongBySongIdAsync(
            [FromServices] ICatalogApplicationService _catalogApplicationService,
            Guid songId
        )
        {
            var result = await _catalogApplicationService.GetSongBySongIdAsync(songId);
            return TypedResults.Ok(result);
        }

        public static async Task<Results<BadRequest, Ok<SongDto>>> CreateSongAsync(
            [FromServices] ICatalogApplicationService _catalogApplicationService,
            [FromBody] SongForCreationDto song
        )
        {
            if (song == null)
            {
                return TypedResults.BadRequest();
            }

            var result = await _catalogApplicationService.CreateSongAsync(song);
            return TypedResults.Ok(result);
        }

        public static async Task<Results<NotFound, NoContent>> DeleteSongAsync(
            [FromServices] ICatalogApplicationService _catalogApplicationService,
            Guid songId
        )
        {
            var result = await _catalogApplicationService.DeleteSongAsync(songId);

            if (result == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.NoContent();
        }

        public static async Task<Results<BadRequest, NotFound, NoContent, Ok<SongDto>>> UpdateSongAsync(
            [FromServices] ICatalogApplicationService _catalogApplicationService,
            [FromBody] SongForUpdateDto song,
            Guid songId
        )
        {
            if (song == null)
            {
                return TypedResults.BadRequest();
            }

            var result = await _catalogApplicationService.UpdateSongAsync(songId, song);

            if (result.Success && result.SongUpserted != null)
            {
                return TypedResults.Ok(result.SongUpserted);
            }

            return TypedResults.NoContent();
        }
    }
}