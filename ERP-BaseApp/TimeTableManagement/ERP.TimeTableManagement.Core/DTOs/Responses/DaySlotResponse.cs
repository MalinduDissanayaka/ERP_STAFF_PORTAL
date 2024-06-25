using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.TimeTableManagement.Core.DTOs.Responses
{
    public class DaySlotResponse
    {
        public Guid Id { get; set; }
        public DayOfWeek Day { get; set; }
        public Guid? TimetableId { get; set; }
        public ICollection<TimeSlotResponse> TimeSlots { get; set; } = new List<TimeSlotResponse>();
    }
}

