using ERP.TimeTableManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.TimeTableManagement.Core.DTOs.Requests.UpdateRequests
{
    public class UpdateTimeSlotRequest
    {
        public Guid Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Guid? ModuleId { get; set; }
        public Guid? LectureHallId { get; set; }
        public SlotType SlotType { get; set; }
    }
}
