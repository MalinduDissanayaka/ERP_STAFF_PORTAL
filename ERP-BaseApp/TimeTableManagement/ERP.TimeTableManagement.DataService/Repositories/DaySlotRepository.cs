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
    public class DaySlotRepository : GenericRepository<DaySlot>, IDaySlotRepository
    {
        public DaySlotRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<DaySlot>> All()
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
                _logger.LogError(ex, "{Repo} All function error", typeof(DaySlotRepository));
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
                _logger.LogError(ex, "{Repo} Delete function error", typeof(DaySlotRepository));
                throw;
            }
        }

        public override async Task<bool> Update(DaySlot daySlot)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == daySlot.Id);
                if (result == null)
                {
                    return false;
                }
                result.UpdatedDate = DateTime.UtcNow;
                result.TimetableId = daySlot.TimetableId;
                result.TimeSlots = daySlot.TimeSlots;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(DaySlotRepository));
                throw;
            }
        }
    }
}
