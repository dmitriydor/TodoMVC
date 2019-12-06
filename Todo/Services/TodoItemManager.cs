using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Data;
using Todo.Models;

namespace Todo.Services
{
    public class TodoItemManager:ITodoItemManager
    {
        private AppDbContext _context;
        public TodoItemManager(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<TodoItem> TodoItems => _context.TodoItems;
        public TodoItem Delete(int id)
        {
            TodoItem todoDb = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (todoDb != null)
            {
                _context.TodoItems.Remove(todoDb);
                _context.SaveChanges();
            }
            return todoDb;
        }
        public TodoItem Update(TodoItem todo)
        {
            if (todo.Id == 0)
            {
                _context.TodoItems.Add(todo);
            }
            else
            {
                TodoItem todoDb = _context.TodoItems.FirstOrDefault(t => t.Id == todo.Id);
                if(todoDb != null)
                {
                    todoDb.Name = todo.Name;
                    todoDb.Description = todo.Description;
                    todoDb.Date = todo.Date;
                    todoDb.Priority = todo.Priority;
                    todoDb.IsCompleted = todo.IsCompleted;
                }
            }
            _context.SaveChanges();
            return todo;
        }

    }
}
