using System;
using System.Collections.Generic;

namespace SecureTaskManagementPlatform.Models
{
    public class TaskItem
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }
        public List<TaskComment> Comments { get; set; } = new();
    }
}
