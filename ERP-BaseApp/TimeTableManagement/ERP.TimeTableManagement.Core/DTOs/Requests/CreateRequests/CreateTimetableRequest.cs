using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.TimeTableManagement.Core.DTOs.Requests.CreateRequests
{
    public class CreateTimetableRequest
    {
        public Guid? Semester { get; set; }
        public ICollection<CreateDaySlotRequest> DaySlots { get; set; } = new List<CreateDaySlotRequest>();
    }
}
