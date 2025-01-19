using Catalog.Service.Application.Dtos;

namespace Catalog.Service.Infrastructure.Http.Results
{
    public class UpdateSongResult
    {
        public SongDto SongUpserted { get; set; }
        public bool Success { get; set; }
    }
}
