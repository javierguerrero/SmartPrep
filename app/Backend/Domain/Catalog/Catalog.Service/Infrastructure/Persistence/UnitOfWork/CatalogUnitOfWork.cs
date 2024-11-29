using Catalog.Service.Domain.Interfaces;
using Catalog.Service.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Service.Infrastructure.Persistence.UnitOfWork
{
    public class CatalogUnitOfWork : UnitOfWork
    {
        public ISongRepository Songs { get; }
        public CatalogContext _context { get; }

        public CatalogUnitOfWork(
            CatalogContext context,
            ISongRepository songRepository
        ) : base(context)
        {
            _context = context;
            Songs = songRepository;
        }
    }
}