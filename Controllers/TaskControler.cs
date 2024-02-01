using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todolist.Data;
using Todolist.Models;
using Todolist.Repositories;

namespace Todolist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly DataContext _context;
        private readonly ITaskRepositories _taskRepository;

        public TaskController(DataContext context, ITaskRepositories taskRepository)
        {
            _context = context;
            _taskRepository = taskRepository;
        }

        // GET: api/Task
        [HttpGet]
        public async Task<IEnumerable<TaskModels>> GetTasks()
        {
            var tasks = await _taskRepository.GetAllTasks();
            return tasks.ToList();
        }


        // GET: api/Task/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModels>> GetTask(int id)
        {
            var task = await _taskRepository.GetTaskById(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }


        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<TaskModels>> PostTask(TaskModels task)
        {

            await _taskRepository.AddTask(task);

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }



        

        
        
        [HttpPut("{id}")]
        public async Task<IActionResult> AddTask(int id, TaskModels Todolist)
        {
            if (id != Todolist.Id)
            {
                return BadRequest();
            }

            _context.Entry(Todolist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodolistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool TodolistExists(int id)
        {
            return _context.Todolist.Any(e => e.Id == id);
        }

        

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskRepository.DeleteTask(id);

            return NoContent();
        }
    }
}



