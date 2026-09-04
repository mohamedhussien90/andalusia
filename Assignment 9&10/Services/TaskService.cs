using Assignment_8.DTOs;
using Assignment_8.Models;
using Assignment_8.Repositories;
using AutoMapper;

namespace Assignment_8.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repo;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<TaskResponseDto> CreateAsync(CreateTaskRequest request)
        {
            var task = _mapper.Map<TaskItem>(request);
            var created = await _repo.CreateAsync(task);
            return _mapper.Map<TaskResponseDto>(created);
        }

        public async Task<TaskResponseDto> UpdateAsync(int id, UpdateTaskRequest request)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) throw new Exception($"Task {id} not found.");

            _mapper.Map(request, existing);
            var updated = await _repo.UpdateAsync(existing);
            return _mapper.Map<TaskResponseDto>(updated);
        }

        public async Task<TaskResponseDto> GetByIdAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) throw new Exception($"Task {id} not found.");
            return _mapper.Map<TaskResponseDto>(existing);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) throw new Exception($"Task {id} not found.");
            await _repo.DeleteAsync(existing);
        }
    }
}
