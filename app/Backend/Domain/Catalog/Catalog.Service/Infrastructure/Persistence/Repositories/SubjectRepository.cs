using Catalog.Service.Domain.Entities;
using Catalog.Service.Domain.Interfaces;
using Catalog.Service.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Service.Infrastructure.Persistence.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly CatalogContext _context;

        public SubjectRepository(CatalogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> GetSubjectsAsync()
        {
            var subjects = await _context.Subjects.ToListAsync();
            return subjects;
        }

        public async Task AddSubjectAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
        }

        public async Task<Subject> GetSubjectAsync(Guid subjectId)
        {
            return await _context.Subjects.FirstOrDefaultAsync(s => s.SubjectId == subjectId);
        }

        public async Task DeleteSubjectAsync(Subject subject)
        {
            await Task.FromResult(_context.Subjects.Remove(subject));
        }

        public async Task UpdateSubjectAsync(Subject subject)
        {
            var subjectUpdate = await GetSubjectAsync(subject.SubjectId);
            if (subjectUpdate != null)
            {
                subjectUpdate.Name = subject.Name;
            }
        }

        public Task<IEnumerable<Subject>> GetSubjectsAsync(List<Guid> subjectIds)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SubjectExists(Guid subjectId)
        {
            throw new NotImplementedException();
        }


    }
}