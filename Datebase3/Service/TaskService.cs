using AutoMapper;
using DataBaseTesting.DataBase;
using DataBaseTesting.Models;
using DataBaseTesting.Repo;
using DataBaseTestingV2.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataBaseTesting.Service
{
    public class TaskService: ITaskService
    {
        private readonly ITaskRepo _repo;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<TaskItemDto>> GetAllAsync()
        {
            var tasks = await _repo.GetAllAsync();
            return _mapper.Map<List<TaskItemDto>>(tasks);
        }

        public async Task<TaskItemDto?> GetByIdAsync(int id)
        {
            var task = await _repo.GetByIdAsync(id);
            return task == null ? null : _mapper.Map<TaskItemDto>(task);
        }

        public async Task<TaskItemDto> CreateAsync(CreateTaskRequest request)
        {
            var entity = _mapper.Map<TaskItem>(request); // CreatedAt is set here via the profile!
            var createdEntity = await _repo.AddAsync(entity);
            return _mapper.Map<TaskItemDto>(createdEntity);
        }

        public async Task<TaskItemDto?> UpdateAsync(int id, UpdateTaskRequest request)
        {
            var entity = _mapper.Map<TaskItem>(request);
            var updatedEntity = await _repo.UpdateAsync(id, entity);
            return updatedEntity == null ? null : _mapper.Map<TaskItemDto>(updatedEntity);
        }
    }
}
