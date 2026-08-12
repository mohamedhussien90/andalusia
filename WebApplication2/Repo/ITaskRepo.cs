using WebApplication2.Taskitem;

namespace WebApplication2.Repo
{
    public interface ITaskRepo
    {
        List<TaskItem> GetAll();
        TaskItem? GetById(int id);
        TaskItem Add(TaskItem task);
        TaskItem? Update(int id, TaskItem task);
        bool Delete(int id);
    }
}
