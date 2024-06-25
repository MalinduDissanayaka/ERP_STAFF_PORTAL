using ERP.ResultManagement.DataServices.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

using ERP.ResultManagement.DataServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.ResultManagement.DataService.Repositories;

namespace ERP.ResultManagement.DataServices.Repositories
{
    public class UnitOfWorks : IUnitOfWorks, IDisposable
    {
        private readonly AppDbContext _context;

        public IComResultsRepository ComResults { get; }

        public IDeieResultsRepository DeieResults { get; }

        public UnitOfWorks(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var logger = loggerFactory.CreateLogger("logs");

            ComResults = new ComResultsRepository(_context, logger);
            DeieResults = new DeieResultsRepository(_context, logger);


        }
        public async Task<bool> CompleteAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}