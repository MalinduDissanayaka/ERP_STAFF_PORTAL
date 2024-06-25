using ERP.ResultManagement.Core.Entities;
using ERP.ResultManagement.DataServices.Repositories.Interfaces;
using ERP.ResultManagement.DataServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.ResultManagement.DataService.Repositories;

namespace ERP.ResultManagement.DataServices.Repositories
{
    public class ComResultsRepository : GenericRepository<ComResults>, IComResultsRepository
    {
        public ComResultsRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {

        }


    }
}