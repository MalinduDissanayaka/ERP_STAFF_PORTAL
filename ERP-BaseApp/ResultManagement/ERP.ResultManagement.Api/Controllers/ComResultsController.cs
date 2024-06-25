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
    public class ComResultsController : BaseController
    {
        public ComResultsController(IUnitOfWorks unitOfWorks, IMapper mapper) : base(unitOfWorks, mapper)
        {
        }


        [HttpGet]
        [Route("{ComId:guid}")]
        public async Task<IActionResult> GetComResults(Guid ComId)
        {
            var comResults = await _unitOfWorks.ComResults.GetAsync(ComId);

            if (comResults == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetComResultsByIdResponse>(comResults);

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddComResults([FromBody] CreateComResultsRequest comResults)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _mapper.Map<ComResults>(comResults);
            await _unitOfWorks.ComResults.AddAsync(result);
            await _unitOfWorks.CompleteAsync();

            return CreatedAtAction(nameof(GetComResults), new { ComId = result.Id }, result);

        }



        [HttpGet("")]
        public async Task<IActionResult> GetAllComResults()
        {
            var comResults = await _unitOfWorks.ComResults.GetAllAsync();

            if (comResults == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<IEnumerable<GetComResultsByResponse>>(comResults);

            return Ok(result);
        }





    }



}
