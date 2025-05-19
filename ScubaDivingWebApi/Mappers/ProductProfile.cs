using AutoMapper;
using Core.Entities;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductDtos, Product>();
        CreateMap<UpdateProductDto, Product>();
    }
}
