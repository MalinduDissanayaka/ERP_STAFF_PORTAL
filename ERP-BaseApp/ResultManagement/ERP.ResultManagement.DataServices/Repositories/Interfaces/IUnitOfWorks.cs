using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ResultManagement.DataServices.Repositories.Interfaces
{
    public interface IUnitOfWorks
    {
        public IComResultsRepository ComResults { get; }
        public IDeieResultsRepository DeieResults { get; }

        Task<bool> CompleteAsync();
    }
}