using GTS_Task.Data.Models;

namespace GTS_Task.DTOs
{
    public class GetAllTasksDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string status { get; set; }
        public string priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}