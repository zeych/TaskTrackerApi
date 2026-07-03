using Microsoft.AspNetCore.Mvc;
using TaskTrackerApi.Models;      // тут теперь TaskItem
using TaskTrackerApi.Services;

namespace TaskTrackerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskItem>> Get() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public ActionResult<TaskItem?> Get(int id)
        {
            var task = _service.GetById(id);
            return task == null ? NotFound() : Ok(task);
        }

        [HttpPost]
        public ActionResult<TaskItem> Post([FromBody] TaskItem task)
        {
            // Автоматическая проверка валидности модели
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = _service.Create(task);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id) =>
            _service.Delete(id) ? NoContent() : NotFound();
    }
}
