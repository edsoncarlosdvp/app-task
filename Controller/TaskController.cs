using AppTask.Data;
using AppTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AppTask.Controller
{
    [ApiController]
    [Route("v1")]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        [Route("tasks")]
        public async Task<IActionResult> GetTasksAsync(
            [FromServices] AppDbContext context
        )
        {
            var tasks = await context.Tasks.AsNoTracking().ToListAsync();
            return Ok(tasks);
        }

        [HttpGet]
        [Route("tasks/{id}")]
        public async Task<IActionResult> GetTasksByIdAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var task = await context.Tasks.AsNoTracking().FirstOrDefaultAsync(task => task.Id == id);
            return task == null ? NotFound() : Ok(task);
        }

        [HttpPost]
        [Route("tasks")]
        public async Task<IActionResult> PostTasksAsync(
            [FromServices] AppDbContext context,
            [FromBody]CreateTodoViewModels models)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var task = new TaskModels
            {
                Done = false,
                Title = models.Title,
            };
            await context.TaskModel.AddAsync(models);
            await context.SaveChangesAsync();
        }
    }
}