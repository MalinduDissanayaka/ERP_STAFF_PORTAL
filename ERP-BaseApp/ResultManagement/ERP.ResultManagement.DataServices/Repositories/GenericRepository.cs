using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ERP.ResultManagement.Core.Entities;
using ERP.ResultManagement.DataServices;
using ERP.ResultManagement.DataServices.Repositories.Interfaces;

namespace ERP.ResultManagement.DataService.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    public readonly ILogger _logger;
    protected AppDbContext _context;
    internal DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context, ILogger logger)
    {
        _logger = logger;
        _context = context;

        _dbSet = context.Set<T>();
    }

    public virtual async Task<bool> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }



    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        try
        {
            return await _dbSet.Where(x => x.Status == 1)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.AddedDate)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} All function error",
                typeof(T));
            throw;
        }
    }

    public virtual async Task<T?> GetAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }


}