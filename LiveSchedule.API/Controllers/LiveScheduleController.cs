using LiveSchedule.API.DTOs;
using LiveSchedule.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveSchedule.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class LiveScheduleController : ControllerBase
    {
        private readonly ILiveScheduleService _service;

        public LiveScheduleController(ILiveScheduleService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LiveScheduleDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<LiveScheduleDto>>> GetAll()
        {
            var result = await _service.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(typeof(LiveScheduleDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<LiveScheduleDto>> Get(int id)
        {
            var result = await _service.Get(id);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(LiveScheduleDto), StatusCodes.Status201Created)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post(LiveScheduleDto liveSchedule)
        {
            var result = await _service.Add(liveSchedule);
            if (!result.Success)
            {
                return BadRequest(new JsonResult(new { ErrorMessage = "An error occurred while inserting the register." }));
            }

            return CreatedAtRoute("GetById", new { id = result.LiveSchedule.Id }, result.LiveSchedule);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, LiveScheduleDto liveSchedule)
        {
            var result = await _service.Update(id, liveSchedule);
            if (!result)
            {
                return BadRequest(new JsonResult(new { ErrorMessage = "An error occurred while updating the register." }));
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (!result)
            {
                return BadRequest(new JsonResult(new { ErrorMessage = "An error occurred while removing the register." }));
            }

            return NoContent();
        }
    }
}
