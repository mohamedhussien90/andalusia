using WebApplication2.Taskitem;

namespace WebApplication2.Service
{
    public interface ITaskService
    {
        List<TaskItem> GetAll();
        TaskItem GetById(int id);
        TaskItem Create(TaskItem task);
        TaskItem Update(int id, TaskItem task);
        void Delete(int id);
    }
}
