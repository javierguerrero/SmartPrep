using Catalog.Service.Application.Dtos;
using Catalog.Service.Domain.Entities;
using Catalog.Service.Infrastructure.Http.Results;

namespace Catalog.Service.Application.Interfaces
{
    public interface ICatalogApplicationService
    {
        //El servicio de aplicación tendrá varios Casos de Uso
        //Por ejemplo, GetSongsAsync() seria  un Caso de Uso
        Task<List<SongDto>> GetSongsAsync();

        Task<bool> SongExistsAsync(Guid songId);

        Task<SongDto> CreateSongAsync(SongForCreationDto song);

        Task<bool?> DeleteSongAsync(Guid songId);

        Task<SongDto> GetSongBySongIdAsync(Guid songId);

        Task<UpdateSongResult> UpdateSongAsync(Guid songId, SongForUpdateDto song);

        ///

        Task<List<SubjectDto>> GetSubjectsAsync();
        Task<SubjectDto> CreateSubjectAsync(SubjectForCreationDto subject);
        Task<SubjectDto> GetSubjectBySubjectIdAsync(Guid subjectId);
        Task<bool?> DeleteSubjectAsync(Guid subjectId);
        Task<UpdateSubjectResult> UpdateSubjectAsync(Guid subjectId, SubjectForUpdateDto subject);
    }
}