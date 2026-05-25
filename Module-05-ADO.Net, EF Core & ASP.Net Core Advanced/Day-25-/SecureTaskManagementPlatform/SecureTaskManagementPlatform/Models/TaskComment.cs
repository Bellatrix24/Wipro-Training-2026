using System;

namespace SecureTaskManagementPlatform.Models
{
    public class TaskComment
    {
        public int CommentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int TaskId { get; set; }
        public TaskItem? TaskItem { get; set; }
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }
    }
}
