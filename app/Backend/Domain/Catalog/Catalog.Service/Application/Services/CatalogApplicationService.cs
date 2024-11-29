using AutoMapper;
using Catalog.Service.Application.Dtos;
using Catalog.Service.Application.Interfaces;
using Catalog.Service.Infrastructure.Persistence.UnitOfWork;

namespace Catalog.Service.Application.Services
{
    public partial class CatalogApplicationService : ICatalogApplicationService
    {
        private readonly CatalogUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;   

        public CatalogApplicationService(CatalogUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SongDto>> GetSongsAsync()
        {
            var songsFromRepo = await _unitOfWork.Songs.GetSongsAsync();
            var songs = _mapper.Map<List<SongDto>>(songsFromRepo);

            return songs;
        }
    }
}
