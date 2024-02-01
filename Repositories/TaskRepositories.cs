
using Microsoft.EntityFrameworkCore;
using Todolist.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todolist.Models;
using System.Collections;

namespace Todolist.Repositories
{
    public class TaskRepositories : ITaskRepositories
    {
        private readonly DataContext _context;

        public TaskRepositories(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskModels>> GetAllTasks()
        {
            try
            {
                return await _context.Todolist.OrderBy(p => p.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it based on your application's needs.
                throw;
            }
        }

        public async Task<TaskModels> GetTaskById(int id)
        {
            return await _context.Todolist.FindAsync(id);
        }

        public async Task AddTask(TaskModels task)
        {
            _context.Todolist.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTask(TaskModels task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(int id)
        {
            var taskToDelete = await _context.Todolist.FindAsync(id);
            if (taskToDelete != null)
            {
                _context.Todolist.Remove(taskToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
