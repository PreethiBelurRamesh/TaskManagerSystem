using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public DateTime? DateAdded { get; set; }
        public string? Comment1 { get; set; }
        public int? CommentType { get; set; }
        public DateTime? ReminderDate { get; set; }
        public int? TaskId { get; set; }

        public virtual CommentType? CommentTypeNavigation { get; set; }
        public virtual Task? Task { get; set; }
    }
}
