using AutoMapper;
using Catalog.Service.Application.Dtos;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.Application.Mappers
{
    public class SubjectMapper : Profile
    {
        public SubjectMapper()
        {
            CreateMap<Subject, SubjectDto>();
            CreateMap<SubjectForCreationDto, Subject>();
            CreateMap<SubjectForUpdateDto, Subject>();
        }
    }
}