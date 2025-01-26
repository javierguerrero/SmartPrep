using Catalog.Service.Application.Dtos;
using Catalog.Service.Application.Interfaces;
using Catalog.Service.Domain.Entities;
using Catalog.Service.Infrastructure.Http.Results;

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

        public async Task<SubjectDto> GetSubjectBySubjectIdAsync(Guid subjectId)
        {
            var subjectFromRepo = await _unitOfWork.Subjects.GetSubjectAsync(subjectId);

            if (subjectFromRepo is null)
            {
                return null;
            }

            var subject = _mapper.Map<SubjectDto>(subjectFromRepo);
            return subject;
        }

        public async Task<bool?> DeleteSubjectAsync(Guid subjectId)
        {
            var subjectFromRepo = await _unitOfWork.Subjects.GetSubjectAsync(subjectId);
            if (subjectFromRepo is null)
            {
                return null;
            }

            await _unitOfWork.Subjects.DeleteSubjectAsync(subjectFromRepo);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Deleting subject {subjectId} failed on save");
            }

            return true;
        }

        public async Task<UpdateSubjectResult> UpdateSubjectAsync(Guid subjectId, SubjectForUpdateDto subject)
        {
            UpdateSubjectResult result = new();
            var subjectFromRepo = await _unitOfWork.Subjects.GetSubjectAsync(subjectId);

            if (subjectFromRepo is null)
            {
                var subjectToAdd = _mapper.Map<Subject>(subject);
                subjectToAdd.SubjectId = subjectId;

                await _unitOfWork.Subjects.AddSubjectAsync(subjectToAdd);

                if (!await _unitOfWork.SaveAsync())
                {
                    throw new Exception($"Upserting subject {subjectId} failed on save");
                }

                result.SubjectUpserted = _mapper.Map<SubjectDto>(subjectToAdd);
                result.Success = true;

                return result;
            }

            _mapper.Map(subject, subjectFromRepo);
            await _unitOfWork.Subjects.UpdateSubjectAsync(subjectFromRepo);
            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Update subject {subjectId} failed on save");
            }

            result.Success = true;
            return result;
        }
    }
}