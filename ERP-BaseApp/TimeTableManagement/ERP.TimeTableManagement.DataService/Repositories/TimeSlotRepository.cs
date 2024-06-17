using ERP.TimeTableManagement.Core.Entities;
using ERP.TimeTableManagement.DataService.Data;
using ERP.TimeTableManagement.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.TimeTableManagement.DataService.Repositories
{
    public class TimeSlotRepository : GenericRepository<TimeSlot>, ITimeSlotRepository
    {
        public TimeSlotRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<TimeSlot>> All()
        {
            try
            {
                return await _dbSet.Where(x => x.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.CreatedDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(TimeSlotRepository));
                throw;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
                if (result == null)
                {
                    return false;
                }
                result.Status = 0;
                result.UpdatedDate = DateTime.UtcNow;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(TimeSlotRepository));
                throw;
            }
        }

        public override async Task<bool> Update(TimeSlot timeSlot)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == timeSlot.Id);
                if (result == null)
                {
                    return false;
                }
                result.UpdatedDate = DateTime.UtcNow;
                result.StartTime = timeSlot.StartTime;
                result.EndTime = timeSlot.EndTime;
                
                result.DaySlotId = timeSlot.DaySlotId;
                result.ModuleId = timeSlot.ModuleId;
                result.LectureHallId = timeSlot.LectureHallId;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(TimeSlotRepository));
                throw;
            }
        }
    }
}
