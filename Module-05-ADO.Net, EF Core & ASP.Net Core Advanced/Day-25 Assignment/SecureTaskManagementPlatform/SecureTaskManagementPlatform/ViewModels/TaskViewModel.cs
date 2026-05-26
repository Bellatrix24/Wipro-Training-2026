using System;
using System.ComponentModel.DataAnnotations;

namespace SecureTaskManagementPlatform.ViewModels
{
    public class TaskViewModel
    {
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(150, ErrorMessage = "Title cannot exceed 150 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s.,!?-]+$", ErrorMessage = "Title contains invalid characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        [Required(ErrorMessage = "Due date is required.")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(1);
    }
}
