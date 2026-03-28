using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.DTOs;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TaskController : Controller
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service) {
            this._service = service;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskDTO dto) {
            return CreatedAtAction(nameof(Create),
                await _service.Create(dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id) {
            await _service.Delete(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Find() {
            return Ok(await _service.Find());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTaskDTO dto) {
            return Ok(await _service.Update(dto));
        }
    }
}
