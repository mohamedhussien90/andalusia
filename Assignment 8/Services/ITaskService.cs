using Assignment_8.DTOs;

namespace Assignment_8.Services
{
    public interface ITaskService
    {
        Task<TaskResponseDto> CreateAsync(CreateTaskRequest request);
        Task<TaskResponseDto> UpdateAsync(int id, UpdateTaskRequest request);
        Task<TaskResponseDto> GetByIdAsync(int id);
    }
}
