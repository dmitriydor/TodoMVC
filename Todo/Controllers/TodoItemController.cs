using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;
using Todo.Services;

namespace Todo.Controllers
{
    public class TodoItemController:Controller
    {
        private ITodoItemManager _todoItemManager;
        public TodoItemController(ITodoItemManager todoItemManager)
        {
            _todoItemManager = todoItemManager;
        }
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
            return View(todo);
        }
        public IActionResult AddTodoItem(TodoItem todo)
        {
            return View(todo);
        }
    }
}
