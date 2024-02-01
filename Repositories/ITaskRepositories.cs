using Microsoft.EntityFrameworkCore;
using Todolist.Models;

namespace Todolist.Repositories
{
    public interface ITaskRepositories
    {
        Task<IEnumerable<TaskModels>> GetAllTasks();
        Task<TaskModels> GetTaskById(int id);
        Task AddTask(TaskModels task);
        Task DeleteTask(int id);
        Task UpdateTask(TaskModels task);
    }
}
