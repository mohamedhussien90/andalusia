using WebApplication2.Exceptions;
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

        public List<TaskItem> GetAll() => _repo.GetAll();

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
