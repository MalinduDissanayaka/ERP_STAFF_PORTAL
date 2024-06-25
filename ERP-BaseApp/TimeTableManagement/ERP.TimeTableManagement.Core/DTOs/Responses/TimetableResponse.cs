using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.TimeTableManagement.Core.DTOs.Responses
{
    public class TimetableResponse
    {
        public Guid TimetableId { get; set; }
        public Guid? Semester { get; set; }
        public ICollection<DaySlotResponse> DaySlots { get; set; } = new List<DaySlotResponse>();
    }
}
