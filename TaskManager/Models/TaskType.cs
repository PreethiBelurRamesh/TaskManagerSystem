using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public partial class TaskType
    {
        public TaskType()
        {
            Tasks = new HashSet<Task>();
        }

        public int TaskTypeId { get; set; }
        public string TaskTypeName { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
