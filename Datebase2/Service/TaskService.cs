using DataBaseTesting.DataBase;
using DataBaseTesting.Models;
using DataBaseTesting.Repo;
using Microsoft.EntityFrameworkCore;

namespace DataBaseTesting.Service
{
    public class TaskService: ITaskService
    {
        private readonly ITaskRepo _repo;

        public TaskService(ITaskRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<TaskItem> CreateAsync(TaskItem task)
        {
            return await _repo.AddAsync(task);
        }

        public async Task<TaskItem?> UpdateAsync(int id, TaskItem task)
        {
            return await _repo.UpdateAsync(id, task);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
