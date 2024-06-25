using AutoMapper;
using ERP.TimeTableManagement.Core.DTOs.Requests.UpdateRequests;
using ERP.TimeTableManagement.Core.DTOs.Requests.CreateRequests;
using ERP.TimeTableManagement.Core.DTOs.Responses;
using ERP.TimeTableManagement.Core.Entities;
using ERP.TimeTableManagement.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.TimeTableManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotController : BaseController
    {
        public TimeSlotController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("{timeSlotId:guid}")]
        public async Task<IActionResult> GetTimeSlot(Guid timeSlotId)
        {
            var timeSlot = await _unitOfWork.TimeSlots.GetById(timeSlotId);
            if (timeSlot == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<TimeSlotResponse>(timeSlot);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddTimeSlot([FromBody] CreateTimeSlotRequest timeSlotRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timeSlot = _mapper.Map<TimeSlot>(timeSlotRequest);
            await _unitOfWork.TimeSlots.Add(timeSlot);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetTimeSlot), new { timeSlotId = timeSlot.Id }, timeSlot);
        }

        [HttpPut("{timeSlotId:guid}")]
        public async Task<IActionResult> UpdateTimeSlot(Guid timeSlotId, [FromBody] UpdateTimeSlotRequest timeSlotRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingTimeSlot = await _unitOfWork.TimeSlots.GetById(timeSlotId);
            if (existingTimeSlot == null)
            {
                return NotFound();
            }

            _mapper.Map(timeSlotRequest, existingTimeSlot);
            await _unitOfWork.TimeSlots.Update(existingTimeSlot);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllTimeSlots()
        {
            var timeSlots = await _unitOfWork.TimeSlots.All();
            var result = _mapper.Map<IEnumerable<TimeSlotResponse>>(timeSlots);
            return Ok(result);
        }

        [HttpDelete("{timeSlotId:guid}")]
        public async Task<IActionResult> DeleteTimeSlot(Guid timeSlotId)
        {
            var timeSlot = await _unitOfWork.TimeSlots.GetById(timeSlotId);
            if (timeSlot == null)
            {
                return NotFound();
            }

            await _unitOfWork.TimeSlots.Delete(timeSlotId);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
