using AutoMapper;
using Core.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SearchHistory, SearchHistoryDto>();
        CreateMap<CreateSearchHistoryDto, SearchHistory>();
    }
}
