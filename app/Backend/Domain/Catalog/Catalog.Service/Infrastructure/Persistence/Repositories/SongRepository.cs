using Catalog.Service.Domain.Entities;
using Catalog.Service.Domain.Interfaces;
using Catalog.Service.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Service.Infrastructure.Persistence.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly CatalogContext _context;

        public SongRepository(CatalogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Song>> GetSongsAsync()
        {
            var songs = await _context.Songs.ToListAsync();
            return songs;
        }

        public async Task<IEnumerable<Song>> GetSongsAsync(List<Guid> songIds)
        {
            return await _context.Songs.Where(s => songIds.Contains(s.SongId))
                .OrderBy(s => s.Title)
                .ToListAsync();
        }

        public async Task AddSongAsync(Song song)
        {
            await _context.Songs.AddAsync(song);
        }

        public async Task DeleteSongAsync(Song song)
        {
            await Task.FromResult(_context.Songs.Remove(song));
        }

        public async Task UpdateSongAsync(Song song)
        {
            var songUpdate = await GetSongAsync(song.SongId);
            if (songUpdate != null)
            {
                songUpdate.Title = song.Title;
            }
        }

        public async Task<Song> GetSongAsync(Guid songId)
        {
            return await _context.Songs.FirstOrDefaultAsync(s => s.SongId == songId);
        }

        public async Task<bool> SongExists(Guid songId)
        {
            return await _context.Songs.AnyAsync(s => s.SongId == songId);
        }
    }
}