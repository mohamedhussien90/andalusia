using Assignment_8.Models;

namespace Assignment_8.Repositories
{
    public interface ITaskRepository
    {
        Task<TaskItem> CreateAsync(TaskItem task);
        Task<TaskItem?> GetByIdAsync(int id);
        Task<TaskItem> UpdateAsync(TaskItem task);
    }
}
