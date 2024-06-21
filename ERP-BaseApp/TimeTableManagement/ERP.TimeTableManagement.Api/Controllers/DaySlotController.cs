using AutoMapper;
using ERP.TimeTableManagement.Core.DTOs.Requests.CreateRequests;
using ERP.TimeTableManagement.Core.DTOs.Requests.UpdateRequests;
using ERP.TimeTableManagement.Core.DTOs.Responses;
using ERP.TimeTableManagement.Core.Entities;
using ERP.TimeTableManagement.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.TimeTableManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaySlotController : BaseController
    {
        public DaySlotController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("{daySlotId:guid}")]
        public async Task<IActionResult> GetDaySlot(Guid daySlotId)
        {
            var daySlot = await _unitOfWork.DaySlots.GetById(daySlotId);
            if (daySlot == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<DaySlotResponse>(daySlot);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddDaySlot([FromBody] CreateDaySlotRequest daySlotRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var daySlot = _mapper.Map<DaySlot>(daySlotRequest);
            await _unitOfWork.DaySlots.Add(daySlot);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDaySlot), new { daySlotId = daySlot.Id }, daySlot);
        }

        [HttpPut("{daySlotId:guid}")]
        public async Task<IActionResult> UpdateDaySlot(Guid daySlotId, [FromBody] UpdateDaySlotRequest daySlotRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingDaySlot = await _unitOfWork.DaySlots.GetById(daySlotId);
            if (existingDaySlot == null)
            {
                return NotFound();
            }

            _mapper.Map(daySlotRequest, existingDaySlot);
            await _unitOfWork.DaySlots.Update(existingDaySlot);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllDaySlots()
        {
            var daySlots = await _unitOfWork.DaySlots.All();
            var result = _mapper.Map<IEnumerable<DaySlotResponse>>(daySlots);
            return Ok(result);
        }

        [HttpDelete("{daySlotId:guid}")]
        public async Task<IActionResult> DeleteDaySlot(Guid daySlotId)
        {
            var daySlot = await _unitOfWork.DaySlots.GetById(daySlotId);
            if (daySlot == null)
            {
                return NotFound();
            }

            await _unitOfWork.DaySlots.Delete(daySlotId);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
