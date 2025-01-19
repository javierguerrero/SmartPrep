using Catalog.Service.Application.Dtos;
using Catalog.Service.Application.Interfaces;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.Application.Services
{
    public partial class CatalogApplicationService : ICatalogApplicationService
    {
        public async Task<List<SubjectDto>> GetSubjectsAsync()
        {
            var subjectsFromRepo = await _unitOfWork.Subjects.GetSubjectsAsync();
            var subjects = _mapper.Map<List<SubjectDto>>(subjectsFromRepo);

            return subjects;
        }

        public async Task<SubjectDto> CreateSubjectAsync(SubjectForCreationDto subject)
        {
            var subjectEntity = _mapper.Map<Subject>(subject);
            await _unitOfWork.Subjects.AddSubjectAsync(subjectEntity);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception("There was an error saving a subject");
            }

            var subjectToReturn = _mapper.Map<SubjectDto>(subjectEntity);
            return subjectToReturn;
        }
    }
}