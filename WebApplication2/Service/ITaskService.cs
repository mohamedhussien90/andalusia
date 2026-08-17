using WebApplication2.Models;
using WebApplication2.Taskitem;

namespace WebApplication2.Service
{
    public interface ITaskService
    {
        PagedResult<TaskItem> GetAll(TaskFilterParams filterParams);
        TaskItem GetById(int id);
        TaskItem Create(TaskItem task);
        TaskItem Update(int id, TaskItem task);
        void Delete(int id);
    }
}
