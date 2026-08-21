using DataBaseTesting.Models;
using DataBaseTestingV2.DTOs;

namespace DataBaseTesting.Service
{
    public interface ITaskService
    {
        Task<List<TaskItemDto>> GetAllAsync();

        Task<TaskItemDto?> GetByIdAsync(int id);

        Task<TaskItemDto> CreateAsync(CreateTaskRequest request);

        Task<TaskItemDto?> UpdateAsync(int id, UpdateTaskRequest request);

    
    }
}
