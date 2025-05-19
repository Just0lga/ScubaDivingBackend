using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace Infrastructure.Mappings
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressCreateDto, Address>();
            CreateMap<AddressUpdateDto, Address>();
            CreateMap<Address, AddressReadDto>();
        }
    }
}
