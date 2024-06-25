using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.TimeTableManagement.Core.DTOs.Requests.UpdateRequests
{
    public class UpdateTimetableRequest
    {
        public Guid TimetableId { get; set; }
        public Guid? Semester { get; set; }
        public ICollection<UpdateDaySlotRequest> DaySlots { get; set; } = new List<UpdateDaySlotRequest>();
    }
}
