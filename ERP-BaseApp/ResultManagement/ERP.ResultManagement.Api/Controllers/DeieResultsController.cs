using AutoMapper;
using ERP.ResultManagement.Core.DTOs.Request;
using ERP.ResultManagement.Core.DTOs.Response;
using ERP.ResultManagement.Core.Entities;
using ERP.ResultManagement.DataServices.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;





namespace ERP.ResultManagement.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DeieResultsController : BaseController
    {
        public DeieResultsController(IUnitOfWorks unitOfWorks, IMapper mapper) : base(unitOfWorks, mapper)
        {
        }


        [HttpGet]
        [Route("{DeieId:guid}")]
        public async Task<IActionResult> GetDeieResults(Guid DeieId)
        {
            var deieResults = await _unitOfWorks.DeieResults.GetAsync(DeieId);

            if (deieResults == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetDeieResultsByIdResponse>(deieResults);

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddDeieResults([FromBody] CreateDeieResultsRequest deieResults)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _mapper.Map<DeieResults>(deieResults);
            await _unitOfWorks.DeieResults.AddAsync(result);
            await _unitOfWorks.CompleteAsync();

            return CreatedAtAction(nameof(GetDeieResults), new { DeieId = result.Id }, result);

        }



        [HttpGet("")]
        public async Task<IActionResult> GetAllDeieResults()
        {
            var deieResults = await _unitOfWorks.DeieResults.GetAllAsync();

            if (deieResults == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<IEnumerable<GetDeieResultsByResponse>>(deieResults);

            return Ok(result);
        }





    }



}