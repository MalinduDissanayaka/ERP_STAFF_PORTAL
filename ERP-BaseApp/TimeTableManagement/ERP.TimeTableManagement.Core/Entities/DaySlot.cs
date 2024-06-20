using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.TimeTableManagement.Core.Entities
{
    public class DaySlot : BaseEntity
    {
        public DaySlot()
        {
            TimeSlots = new HashSet<TimeSlot>();
        }

        public DayOfWeek Day { get; set; }
        public Guid? TimetableId { get; set; }  // Foreign key to Timetable
        public virtual Timetable Timetable { get; set; } = new Timetable();
        public virtual ICollection<TimeSlot> TimeSlots { get; set; }
    }
}