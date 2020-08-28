using System.Linq;
using Todo.Models;

namespace Todo.Services
{
    public interface ITodoItemRepository
    {
        public IQueryable<TodoItem> TodoItems { get; }
        public TodoItem Delete(int id);
        public TodoItem Upsert(TodoItem todo);
    }
}