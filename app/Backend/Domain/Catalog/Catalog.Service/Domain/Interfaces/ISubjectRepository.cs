using Catalog.Service.Domain.Entities;

namespace Catalog.Service.Domain.Interfaces
{
    public interface ISubjectRepository
    {
        Task AddSubjectAsync(Subject subject);
        Task<bool> SubjectExists(Guid subjectId);
        Task DeleteSubjectAsync(Subject subject);
        Task<Subject> GetSubjectAsync(Guid subjectId);
        Task<IEnumerable<Subject>> GetSubjectsAsync(List<Guid> subjectIds);
        Task<IEnumerable<Subject>> GetSubjectsAsync();
        Task UpdateSubjectAsync(Subject subject);
    }
}