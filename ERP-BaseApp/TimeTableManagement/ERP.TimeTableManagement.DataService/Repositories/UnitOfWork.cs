using ERP.TimeTableManagement.DataService.Repositories.Interfaces;
using ERP.TimeTableManagement.DataService.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ERP.TimeTableManagement.DataService.Repositories
{

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public ITimetableRepository Timetables { get; }
        public IDaySlotRepository DaySlots { get; }
        public ITimeSlotRepository TimeSlots { get; }
        public IModuleRepository Modules { get; }
        public ILectureHallRepository LectureHalls { get; }

        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var logger = loggerFactory.CreateLogger("logs");

            Timetables = new TimetableRepository(_context, logger);
            DaySlots = new DaySlotRepository(_context, logger);
            TimeSlots = new TimeSlotRepository(_context, logger);
            Modules = new ModuleRepository(_context, logger);
            LectureHalls = new LectureHallRepository(_context, logger);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    
    }
}
