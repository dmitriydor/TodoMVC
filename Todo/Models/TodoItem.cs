using System;
using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;

        [DataType(DataType.Date)] public DateTime Date { get; set; }

        public int Priority { get; set; }
        public string UserEmail { get; set; }
    }
}