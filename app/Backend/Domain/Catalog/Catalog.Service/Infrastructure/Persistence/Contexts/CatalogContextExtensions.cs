
using Catalog.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Service.Infrastructure.Persistence.Contexts
{
    public partial class CatalogContext : DbContext
    {
        public void EnsureSeedDataForContext()
        {
            Database.EnsureDeleted();
            Database.Migrate();
            SaveChanges();

            List<Song> songs = new List<Song>()
            {
                new Song()
                {
                   SongId = new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
                   Title = "La Bamba"
                    
                }
            };

            Songs.AddRange(songs);
            SaveChanges();
        }
    }
}
