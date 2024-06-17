using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.TimeTableManagement.Core.Entities
{
    public class Module : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string Code { get; set; } = String.Empty;
        public virtual ICollection<TimeSlot> TimeSlots { get; set; } = new HashSet<TimeSlot>();
    }
}