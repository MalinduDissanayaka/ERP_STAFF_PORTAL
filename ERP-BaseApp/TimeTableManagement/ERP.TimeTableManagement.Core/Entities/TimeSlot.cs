using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ERP.TimeTableManagement.Core.Entities
{
    public class TimeSlot : BaseEntity
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Guid? ModuleId { get; set; }  // Foreign key to Module
        public Guid? LectureHallId { get; set; }  // Foreign key to LectureHall
        public Guid? DaySlotId { get; set; }  // Foreign key to DaySlot
        public SlotType SlotType { get; set; } // Enum for Lecture, Lab, Project, Common

        public virtual Module Module { get; set; } = new Module();
        public virtual LectureHall LectureHall { get; set; } = new LectureHall();
        public virtual DaySlot DaySlot { get; set; } = new DaySlot();
    }

    public enum SlotType
    {
        Lecture,
        Lab,
        Project,
        Common
    }
}
