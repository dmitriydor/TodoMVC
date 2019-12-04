using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Data;

namespace Todo.Services
{
    public class TodoItemManager:ITodoItemManager
    {
        private AppDbContext _context;
        public TodoItemManager(AppDbContext context)
        {
            _context = context;
        }

    }
}
