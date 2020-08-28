using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Repositories;

namespace Todo.Controllers
{
    [Authorize]
    public class TodoItemController : Controller
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemController(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_todoItemRepository.TodoItems.FirstOrDefault(t => t.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(TodoItem todo)
        {
            if (ModelState.IsValid)
            {
                var todoItem = _todoItemRepository.Upsert(todo);
                if (todoItem != null) return Redirect("/Main/Index");
            }

            return NotFound();
        }

        public IActionResult AddTodoItem()
        {
            return View("Edit", new TodoItem());
            ;
        }

        public IActionResult Delete(int id)
        {
            _todoItemRepository.Delete(id);
            return Redirect("/Main/Index");
        }

        public IActionResult ToComplete(int id)
        {
            var todo = _todoItemRepository.TodoItems.FirstOrDefault(t => t.Id == id);
            if (todo.IsCompleted == false)
                todo.IsCompleted = true;
            else
                todo.IsCompleted = false;
            _todoItemRepository.Upsert(todo);
            return Redirect("/Main/Index");
        }
    }
}