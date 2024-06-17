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
    public class LectureHallRepository : GenericRepository<LectureHall>, ILectureHallRepository
    {
        public LectureHallRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<LectureHall>> All()
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
                _logger.LogError(ex, "{Repo} All function error", typeof(LectureHallRepository));
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
                _logger.LogError(ex, "{Repo} Delete function error", typeof(LectureHallRepository));
                throw;
            }
        }

        public override async Task<bool> Update(LectureHall lectureHall)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == lectureHall.Id);
                if (result == null)
                {
                    return false;
                }
                result.UpdatedDate = DateTime.UtcNow;
                result.Name = lectureHall.Name;
                result.Capacity = lectureHall.Capacity;
               
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(LectureHallRepository));
                throw;
            }
        }
    }
}
