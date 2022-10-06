using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public partial class Task
    {
        public Task()
        {
            Comments = new HashSet<Comment>();
        }

        public int TaskId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? RequiredBy { get; set; }
        public string? TaskDescription { get; set; }
        public int? TaskStatus { get; set; }
        public string? TaskStatusName { get; set; }
        public int? TaskType { get; set; }
        public string? TaskTypeName { get; set; }
        public int? AssignedTo { get; set; }
        public string? AssignedUserName { get; set; }
        public DateTime? NextActionDate { get; set; }
        public string? CommentText { get; set; }
        public string? CommentTypeName { get; set; }

        public virtual User? AssignedToNavigation { get; set; }
        public virtual TaskStatus? TaskStatusNavigation { get; set; }
        public virtual TaskType? TaskTypeNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
