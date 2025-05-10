using GTS_Task.Data.Models;
using GTS_Task.Helpers;
using System.ComponentModel.DataAnnotations;

namespace GTS_Task.DTOs
{
    public class TodoTaskDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }


        [CustomValidation(typeof(DateValidator), nameof(DateValidator.ValidateFutureDate))]
        public DateTime? DueDate { get; set; }
    }
}
