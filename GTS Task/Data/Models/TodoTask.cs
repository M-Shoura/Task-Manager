using System.ComponentModel.DataAnnotations;

namespace GTS_Task.Data.Models
{
    public class TodoTask
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public DateTime CreatedDate { get; set; } 
        public DateTime? DueDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
