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

namespace ERP.ResultManagement.DataService.Repositories
{
    public class DeieResultsRepository : GenericRepository<DeieResults>, IDeieResultsRepository
    {
        public DeieResultsRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {

        }


    }
}