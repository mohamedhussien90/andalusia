namespace Assignment_8.DTOs
{
    public class TaskResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }

        public int UserId { get; set; }
    }
}
