// ProductImageProfile.cs
using AutoMapper;
using Core.Dtos;
using Core.Entities;

public class ProductImageProfile : Profile
{
    public ProductImageProfile()
    {
        CreateMap<ProductImageCreateDto, ProductImage>();
        CreateMap<ProductImage, ProductImageReadDto>();
    }
}
