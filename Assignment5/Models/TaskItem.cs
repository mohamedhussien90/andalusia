namespace Assignment5.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; } 
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; }

        public bool IsCompleted { get; set; }
    }
}
