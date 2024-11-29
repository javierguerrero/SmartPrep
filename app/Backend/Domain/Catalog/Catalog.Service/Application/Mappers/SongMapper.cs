using AutoMapper;
using Catalog.Service.Application.Dtos;
using Catalog.Service.Domain.Entities;

namespace Catalog.Service.Application.Mappers
{
    public class SongMapper : Profile
    {
        public SongMapper()
        {
            CreateMap<Song, SongDto>();
        }
    }
}
