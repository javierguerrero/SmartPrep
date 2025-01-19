using AutoMapper;
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
    }
}