using AutoMapper;
using ERP.TimeTableManagement.Core.DTOs.Responses;
using ERP.TimeTableManagement.Core.Entities;

namespace ERP.TimeTableManagement.Api.MappingProfiles
{
    public class DomainToResponse: Profile
    {
        public DomainToResponse() 
        
        {
            CreateMap<DaySlot, DaySlotResponse>()
                .ForMember(dest => dest.DaySlotId, opt => opt.MapFrom(src => src.Id));
            CreateMap<LectureHall, LectureHallResponse>()
                .ForMember(dest => dest.LectureHallId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Module, ModuleResponse>()
                .ForMember(dest => dest.ModuleId, opt => opt.MapFrom(src => src.Id));
            CreateMap<TimeSlot, TimeSlotResponse>()
                .ForMember(dest => dest.TimeSlotId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Timetable, TimetableResponse>()
                .ForMember(dest => dest.TimetableId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
