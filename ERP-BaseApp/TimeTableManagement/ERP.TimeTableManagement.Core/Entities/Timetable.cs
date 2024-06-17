using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.TimeTableManagement.Core.Entities
{
   
        public class Timetable : BaseEntity
        {
            public Timetable()
            {
                DaySlots = new HashSet<DaySlot>();
            }

            public Guid? Semester { get; set; }
            public virtual ICollection<DaySlot> DaySlots { get; set; }

           
        }
    
}