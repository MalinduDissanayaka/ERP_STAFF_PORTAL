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
    public class ModuleController : BaseController
    {
        public ModuleController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("{moduleId:guid}")]
        public async Task<IActionResult> GetModule(Guid moduleId)
        {
            var module = await _unitOfWork.Modules.GetById(moduleId);
            if (module == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<ModuleResponse>(module);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddModule([FromBody] CreateModuleRequest moduleRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var module = _mapper.Map<Module>(moduleRequest);
            await _unitOfWork.Modules.Add(module);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetModule), new { moduleId = module.Id }, module);
        }

        [HttpPut("{moduleId:guid}")]
        public async Task<IActionResult> UpdateModule(Guid moduleId, [FromBody] UpdateModuleRequest moduleRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingModule = await _unitOfWork.Modules.GetById(moduleId);
            if (existingModule == null)
            {
                return NotFound();
            }

            _mapper.Map(moduleRequest, existingModule);
            await _unitOfWork.Modules.Update(existingModule);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllModules()
        {
            var modules = await _unitOfWork.Modules.All();
            var result = _mapper.Map<IEnumerable<ModuleResponse>>(modules);
            return Ok(result);
        }

        [HttpDelete("{moduleId:guid}")]
        public async Task<IActionResult> DeleteModule(Guid moduleId)
        {
            var module = await _unitOfWork.Modules.GetById(moduleId);
            if (module == null)
            {
                return NotFound();
            }

            await _unitOfWork.Modules.Delete(moduleId);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
