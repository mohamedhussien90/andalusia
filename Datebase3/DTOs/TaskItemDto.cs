namespace DataBaseTestingV2.DTOs
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateTaskRequest
    {
        public string Title { get; set; }
        public int UserId { get; set; }
    }

    public class UpdateTaskRequest
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
