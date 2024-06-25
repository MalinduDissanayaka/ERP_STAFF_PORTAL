using AutoMapper;
using ERP.ResultManagement.Core.DTOs.Request;
using ERP.ResultManagement.Core.DTOs.Response;

using ERP.ResultManagement.Core.Entities;

namespace ERP.ResultManagement.Api.MappingProfiles;

public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        CreateMap<ComResults, GetComResultsByResponse>()

            .ForMember(dest => dest.ComId, opt => opt.MapFrom(src => src.Id));

        CreateMap<ComResults, GetComResultsByIdResponse>()
            .ForMember(dest => dest.ComId, opt => opt.MapFrom(src => src.Id));

        CreateMap<DeieResults, GetDeieResultsByResponse>()
            .ForMember(dest => dest.DEIEid, opt => opt.MapFrom(src => src.Id));

        CreateMap<DeieResults, GetDeieResultsByIdResponse>()
            .ForMember(dest => dest.DEIEid, opt => opt.MapFrom(src => src.Id));
    }


}