using System.Linq;
using Todo.Data;
using Todo.Models;
using Todo.Repositories;

namespace Todo.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly AppDbContext _context;

        public TodoItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<TodoItem> TodoItems => _context.TodoItems;

        public TodoItem Delete(int id)
        {
            var todoDb = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (todoDb != null)
            {
                _context.TodoItems.Remove(todoDb);
                _context.SaveChanges();
            }

            return todoDb;
        }

        public TodoItem Upsert(TodoItem todo)
        {
            if (todo.Id == 0)
            {
                _context.TodoItems.Add(todo);
            }
            else
            {
                var todoDb = _context.TodoItems.FirstOrDefault(t => t.Id == todo.Id);
                if (todoDb != null)
                {
                    todoDb.Name = todo.Name;
                    todoDb.Description = todo.Description;
                    todoDb.Priority = todo.Priority;
                }
            }

            _context.SaveChanges();
            return todo;
        }
    }
}