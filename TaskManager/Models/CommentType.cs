using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public partial class CommentType
    {
        public CommentType()
        {
            Comments = new HashSet<Comment>();
        }

        public int CommentTypeId { get; set; }
        public string CommentTypeName { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
