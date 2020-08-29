using System.Linq;
using Todo.Models;

namespace Todo.Repositories
{
    public interface ITodoItemRepository
    {
        public IQueryable<TodoItem> TodoItems { get; }
        public TodoItem Delete(int id);
        public TodoItem Upsert(TodoItem todo);
    }
}