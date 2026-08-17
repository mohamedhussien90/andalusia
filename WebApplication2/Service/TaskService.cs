using WebApplication2.Exceptions;
using WebApplication2.Models;
using WebApplication2.Repo;
using WebApplication2.Taskitem;

namespace WebApplication2.Service
{
    public class TaskService: ITaskService
    {
        private readonly ITaskRepo _repo;
        
        public TaskService(ITaskRepo repo)
        {
            _repo = repo;
        }

        public PagedResult<TaskItem> GetAll(TaskFilterParams filterParams)
        {
            var query = _repo.GetAll().AsQueryable();

            if (!string.IsNullOrEmpty(filterParams.Search))
            {
                query = query.Where(t => t.Title.Contains(filterParams.Search, StringComparison.OrdinalIgnoreCase));
            }

            if (filterParams.IsCompleted.HasValue)
            {
                query = query.Where(t => t.IsCompleted == filterParams.IsCompleted.Value);
            }

            var sortDictionary = new Dictionary<string, Func<TaskItem, object>>(StringComparer.OrdinalIgnoreCase)
            {
                { "id", t => t.Id },
                { "title", t => t.Title },
                { "isCompleted", t => t.IsCompleted }
            };

            var sortKey = filterParams.SortBy ?? "id";
            if (!sortDictionary.ContainsKey(sortKey))
            {
                sortKey = "id"; 
            }

            query = query.OrderBy(sortDictionary[sortKey]).AsQueryable();

            var totalCount = query.Count();

            var pagedItems = query
                .Skip((filterParams.Page - 1) * filterParams.PageSize)
                .Take(filterParams.PageSize)
                .ToList();

            return new PagedResult<TaskItem>(pagedItems, totalCount, filterParams.Page, filterParams.PageSize);
        }

        public TaskItem GetById(int id)
        {
            var task = _repo.GetById(id);
            if (task == null)
            {
                throw new NotFoundException($"Task with ID {id} was not found.");
            }
            return task;
        }

        public TaskItem Create(TaskItem task)
        {
            var allTasks = _repo.GetAll();
            if (allTasks.Any(t => t.Id == task.Id))
            {
                throw new ConflictException($"A task with the title '{task.Title}' already exists.");
            }
            return _repo.Add(task);
        }

        public TaskItem Update(int id, TaskItem task)
        {
            var updatedTask = _repo.Update(id, task);
            if (updatedTask == null)
            {
                throw new NotFoundException($"Task with ID {id} was not found.");
            }
            return updatedTask;
        }

        public void Delete(int id)
        {
            var success = _repo.Delete(id);
            if (!success)
            {
                throw new NotFoundException($"Task with ID {id} was not found.");
            }
        }
    }
}
