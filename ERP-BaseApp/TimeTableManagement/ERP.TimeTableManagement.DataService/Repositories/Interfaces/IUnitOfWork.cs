using System;
using System.Threading.Tasks;
using ERP.TimeTableManagement.Core.Entities;

namespace ERP.TimeTableManagement.DataService.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITimetableRepository Timetables { get; }
        IDaySlotRepository DaySlots { get; }
        ITimeSlotRepository TimeSlots { get; }
        IModuleRepository Modules { get; }
        ILectureHallRepository LectureHalls { get; }
        Task<int> CompleteAsync();
    }
}
