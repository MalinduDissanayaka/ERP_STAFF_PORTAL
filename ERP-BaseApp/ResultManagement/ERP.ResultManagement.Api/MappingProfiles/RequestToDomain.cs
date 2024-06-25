using AutoMapper;
using ERP.ResultManagement.Core.DTOs.Request;
using ERP.ResultManagement.Core.Entities;

namespace ERP.ResultManagement.Api.MappingProfiles
{
    public class RequestToDomain : Profile
    {

        public RequestToDomain()
        {
            CreateMap<CreateComResultsRequest, ComResults>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.UtcNow));



            CreateMap<CreateDeieResultsRequest, DeieResults>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.UtcNow));


        }

    }
}