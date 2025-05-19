using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace Infrastructure.Mapping
{
    public class FavoriteProfile : Profile
    {
        public FavoriteProfile()
        {
            CreateMap<FavoriteCreateDto, Favorite>();
            CreateMap<Favorite, FavoriteReadDto>();
        }
    }
}
