using WebApplication2.Taskitem;

namespace WebApplication2.Repo
{
    public class TaskRepo: ITaskRepo
    {
        private readonly List<TaskItem> _tasks = new List<TaskItem>();

        public List<TaskItem> GetAll() => _tasks;

        public TaskItem? GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);

        public TaskItem Add(TaskItem task)
        {
            _tasks.Add(task);
            return task;
        }

        public TaskItem? Update(int id, TaskItem task)
        {
            var index = _tasks.FindIndex(t => t.Id == id);
            if (index == -1)
            {
                return null;
            }

            task.Id = id;
            _tasks[index] = task;
            return task;
        }

        public bool Delete(int id)
        {
            var taskToRemove = _tasks.FirstOrDefault(t => t.Id == id);
            if (taskToRemove == null)
            {
                return false;
            }

            _tasks.Remove(taskToRemove);
            return true;
        }
    }
}
