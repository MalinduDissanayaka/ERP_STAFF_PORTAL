using ERP.TimeTableManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.TimeTableManagement.Core.DTOs.Requests.CreateRequests
{
    public class CreateDaySlotRequest
    {
        public DayOfWeek Day { get; set; }
        public Guid? TimetableId { get; set; }
        public ICollection<CreateTimeSlotRequest> TimeSlots { get; set; } = new List<CreateTimeSlotRequest>();
    }
}
