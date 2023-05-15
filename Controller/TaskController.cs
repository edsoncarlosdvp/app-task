using AppTask.Data;
using AppTask.Models;
using AppTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        [HttpPost("tasks")]
        public async Task<IActionResult> PostTasksAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateTodoViewModels model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var task = new TaskModels
            {
                Status = false,
                Name = model.Name,
                Date = DateTime.Now,
            };
            
            try
            {
                await context.Tasks.AddAsync(task);
                await context.SaveChangesAsync();
                return Created($"v1/tasks/{task.Id}", task);
            }
            catch (Exception e) 
            { 
                return BadRequest(e);
            }
        }

        [HttpPut("tasks/{id}")]
        public async Task<IActionResult> PutTasksAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateTodoViewModels model,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var task = await context.Tasks.FirstOrDefaultAsync(task => task.Id == id);

            if (task == null) return NotFound();

            try
            {
                task.Name = model.Name;

                context.Tasks.Update(task);
                await context.SaveChangesAsync();
                return Ok(task);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("tasks/{id}")]
        public async Task<IActionResult> DeleteTasksAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();

            var task = await context.Tasks.FirstOrDefaultAsync(task => task.Id == id);

            if (task == null) return NotFound();

            try
            {
                context.Tasks.Remove(task);
                await context.SaveChangesAsync();
                return Ok("Excluído com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}