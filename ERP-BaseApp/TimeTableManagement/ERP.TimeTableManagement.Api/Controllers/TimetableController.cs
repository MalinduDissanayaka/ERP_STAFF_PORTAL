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
    public class TimetableController : BaseController
    {
        public TimetableController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("{timetableId:guid}")]
        public async Task<IActionResult> GetTimetable(Guid timetableId)
        {
            var timetable = await _unitOfWork.Timetables.GetById(timetableId);
            if (timetable == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<TimetableResponse>(timetable);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddTimetable([FromBody] CreateTimetableRequest timetableRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var timetable = _mapper.Map<Timetable>(timetableRequest);
            await _unitOfWork.Timetables.Add(timetable);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetTimetable), new { timetableId = timetable.Id }, timetable);
        }

        [HttpPut("{timetableId:guid}")]
        public async Task<IActionResult> UpdateTimetable(Guid timetableId, [FromBody] UpdateTimetableRequest timetableRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingTimetable = await _unitOfWork.Timetables.GetById(timetableId);
            if (existingTimetable == null)
            {
                return NotFound();
            }

            _mapper.Map(timetableRequest, existingTimetable);
            await _unitOfWork.Timetables.Update(existingTimetable);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllTimetables()
        {
            var timetables = await _unitOfWork.Timetables.All();
            var result = _mapper.Map<IEnumerable<TimetableResponse>>(timetables);
            return Ok(result);
        }

        [HttpDelete("{timetableId:guid}")]
        public async Task<IActionResult> DeleteTimetable(Guid timetableId)
        {
            var timetable = await _unitOfWork.Timetables.GetById(timetableId);
            if (timetable == null)
            {
                return NotFound();
            }

            await _unitOfWork.Timetables.Delete(timetableId);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
