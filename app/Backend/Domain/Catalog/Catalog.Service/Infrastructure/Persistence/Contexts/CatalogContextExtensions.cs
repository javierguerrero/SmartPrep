
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

            List<Subject> subjects = new List<Subject>()
            {
                new Subject()
                {
                    SubjectId = new Guid("bf237d14-cecb-471e-97d6-65ac9542635e"),
                    Name = "AZ-900",
                    Image = string.Empty
                }
            };


            Songs.AddRange(songs);
            Subjects.AddRange(subjects);
            SaveChanges();
        }
    }
}
