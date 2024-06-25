using AutoMapper;
using ERP.TimeTableManagement.Core.DTOs.Responses;
using ERP.TimeTableManagement.Core.Entities;

namespace ERP.TimeTableManagement.Api.MappingProfiles
{
    public class DomainToResponse: Profile
    {
        public DomainToResponse() 
        
        {
            CreateMap<DaySlot, DaySlotResponse>();
            CreateMap<LectureHall, LectureHallResponse>();
            CreateMap<Module, ModuleResponse>();
            CreateMap<TimeSlot, TimeSlotResponse>();
            CreateMap<Timetable, TimetableResponse>();
        }
    }
}
