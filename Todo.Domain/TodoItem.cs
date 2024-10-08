using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Domain
{
    public class TodoItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Title { get; set; }
        public string? Note { get; set; }
        public bool IsImportant { get; set; } = false;
        public bool IsCompleted { get; set; } = false;
        public required DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }

    }
}