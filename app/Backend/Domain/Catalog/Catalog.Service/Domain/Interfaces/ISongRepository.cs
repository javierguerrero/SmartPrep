using Catalog.Service.Domain.Entities;

namespace Catalog.Service.Domain.Interfaces
{
    public interface ISongRepository
    {
        Task AddSongAsync(Song song);
        Task<bool> SongExists(Guid songId);
        Task DeleteSongAsync(Song song);
        Task<Song> GetSongAsync(Guid songId);
        Task<IEnumerable<Song>> GetSongsAsync(List<Guid> songIds);
        Task<IEnumerable<Song>> GetSongsAsync();
        Task UpdateSongAsync(Song song);
    }
}