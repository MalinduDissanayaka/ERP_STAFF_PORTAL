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
    public class LectureHallController : BaseController
    {
        public LectureHallController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("{lectureHallId:guid}")]
        public async Task<IActionResult> GetLectureHall(Guid lectureHallId)
        {
            var lectureHall = await _unitOfWork.LectureHalls.GetById(lectureHallId);
            if (lectureHall == null)
            {
                return NotFound(new { message = $"Lecture hall with ID {lectureHallId} not found." });
            }

            var result = _mapper.Map<LectureHallResponse>(lectureHall);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddLectureHall([FromBody] CreateLectureHallRequest lectureHallRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lectureHall = _mapper.Map<LectureHall>(lectureHallRequest);
            await _unitOfWork.LectureHalls.Add(lectureHall);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetLectureHall), new { lectureHallId = lectureHall.Id }, lectureHall);
        }

        [HttpPut("{lectureHallId:guid}")]
        public async Task<IActionResult> UpdateLectureHall(Guid lectureHallId, [FromBody] UpdateLectureHallRequest lectureHallRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingLectureHall = await _unitOfWork.LectureHalls.GetById(lectureHallId);
            if (existingLectureHall == null)
            {
                return NotFound(new { message = $"Lecture hall with ID {lectureHallId} not found." });
            }

            _mapper.Map(lectureHallRequest, existingLectureHall);
            await _unitOfWork.LectureHalls.Update(existingLectureHall);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllLectureHalls()
        {
            var lectureHalls = await _unitOfWork.LectureHalls.All();
            var result = _mapper.Map<IEnumerable<LectureHallResponse>>(lectureHalls);
            return Ok(result);
        }

        [HttpDelete("{lectureHallId:guid}")]
        public async Task<IActionResult> DeleteLectureHall(Guid lectureHallId)
        {
            var lectureHall = await _unitOfWork.LectureHalls.GetById(lectureHallId);
            if (lectureHall == null)
            {
                return NotFound(new { message = $"Lecture hall with ID {lectureHallId} not found." });
            }

            await _unitOfWork.LectureHalls.Delete(lectureHallId);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
