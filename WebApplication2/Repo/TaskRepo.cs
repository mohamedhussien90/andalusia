using WebApplication2.Taskitem;

namespace WebApplication2.Repo
{
    public class TaskRepo: ITaskRepo
    {
        private readonly List<TaskItem> _tasks = new List<TaskItem>();


        public TaskRepo()
        {
            // 1. Add the exact "Meeting" tasks required to pass your assignment tests
            Add(new TaskItem { Id = 1,Title = "Morning Team Meeting", IsCompleted = false });
            Add(new TaskItem { Id = 2, Title = "Client Kickoff Meeting", IsCompleted = true });
            Add(new TaskItem { Id = 3, Title = "Design Review Meeting", IsCompleted = false });
            Add(new TaskItem { Id = 4, Title = "Weekly Sync Meeting", IsCompleted = false });

            // 2. Add some specific simulator development tasks
            Add(new TaskItem { Id = 5, Title = "Calibrate UE5 ship buoyancy constraints", IsCompleted = false });
            Add(new TaskItem { Id = 6, Title = "Test Open Sound Control network messaging", IsCompleted = true });
            Add(new TaskItem { Id = 7, Title = "Fix Python radar sweep animation", IsCompleted = false });
            Add(new TaskItem { Id = 8, Title = "Implement KVLCC2 hull form physics", IsCompleted = true });
            Add(new TaskItem { Id = 9, Title = "Design Business Model Canvas slide", IsCompleted = false });
            Add(new TaskItem { Id = 10, Title = "Troubleshoot Blender mesh extrusion", IsCompleted = true });

            // 3. Use a loop to instantly generate the remaining 90 tasks to reach exactly 100!
            for (int i = 11; i <= 100; i++)
            {
                // Alternate the status: Even numbers are completed (true), odd are pending (false)
                bool isDone = (i % 2 == 0);

                // Make every 4th task a "Meeting" so your Postman filter test has plenty of data to find
                string taskTitle = (i % 4 == 0)
                    ? $"Simulator Progress Meeting {i}"
                    : $"General Development Task {i}";

                Add(new TaskItem
                {
                    Title = taskTitle,
                    IsCompleted = isDone
                });
            }
        }

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
