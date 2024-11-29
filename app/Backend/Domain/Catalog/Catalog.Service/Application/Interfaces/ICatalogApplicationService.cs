using Catalog.Service.Application.Dtos;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.Application.Interfaces
{
    public interface ICatalogApplicationService
    {
        //El servicio de aplicación tendrá varios Casos de Uso
        //Por ejemplo, GetSongsAsync() seria  un Caso de Uso
        Task<IEnumerable<SongDto>> GetSongsAsync();
    }
}
