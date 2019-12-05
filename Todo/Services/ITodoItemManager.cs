using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Services
{
    public interface ITodoItemManager
    {
        public TodoItem Delete(int id);
        public TodoItem Create(TodoItem todo);
        public TodoItem Update(TodoItem todo);
    }
}
