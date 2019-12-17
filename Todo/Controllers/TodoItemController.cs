using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;
using Todo.Services;

namespace Todo.Controllers
{
    [Authorize]
    public class TodoItemController:Controller
    {
        private ITodoItemManager _todoItemManager;
        public TodoItemController(ITodoItemManager todoItemManager)
        {
            _todoItemManager = todoItemManager;
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_todoItemManager.TodoItems.FirstOrDefault(t => t.Id == id));
        }
        [HttpPost]
        public IActionResult Edit(TodoItem todo)
        {
            if(ModelState.IsValid)
            {
                var todoItem = _todoItemManager.Update(todo);
                if (todoItem != null)
                {
                    return Redirect("/Main/Index");
                }
            }
            return NotFound();
        }
        public IActionResult AddTodoItem()
        {
            return View("Edit", new TodoItem()); ;
        }
        public IActionResult Delete(int id)
        {
            _todoItemManager.Delete(id);
            return Redirect("/Main/Index");
        }
        public IActionResult ToComplete(int id)
        {
            var todo = _todoItemManager.TodoItems.FirstOrDefault(t => t.Id == id);
            if(todo.IsCompleted == false) 
            {
                todo.IsCompleted = true;
            }
            else
            {
                todo.IsCompleted = false;
            }
            _todoItemManager.Update(todo);
            return Redirect("/Main/Index");
        }
    }
}
