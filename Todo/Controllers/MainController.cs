using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Repositories;

namespace Todo.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        private readonly ITodoItemRepository _context;

        public MainController(ITodoItemRepository context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<TodoItem>
                list = from todo in _context.TodoItems
                    orderby todo.IsCompleted
                    select todo; //добавить вывод только для текущего дня недели
            return View(list);
        }
    }
}