using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_ModuleManagement.DTOs.Request
{
    public class CreateModuleRequest
    {
        public string ModuleName { get; set; } = string.Empty;

        public string ModuleCode { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
        public string ModuleCoordineter { get; set; } = string.Empty;
        public string Lectures { get; set; } = string.Empty;


    }
}
