using ERP.TimeTableManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.TimeTableManagement.Core.DTOs.Requests.UpdateRequests
{
    public class UpdateDaySlotRequest
    {
        public Guid Id { get; set; }
        public DayOfWeek Day { get; set; }
        public Guid? TimetableId { get; set; }
        public ICollection<UpdateTimeSlotRequest> TimeSlots { get; set; } = new List<UpdateTimeSlotRequest>();
    }
}
