using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Data;
using Todo.Models;
using Todo.Services;

namespace Todo.Controllers
{
    [Authorize]
    public class MainController:Controller
    {
        private ITodoItemManager _context;
        public MainController(ITodoItemManager context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<TodoItem> list = from todo in _context.TodoItems orderby todo.IsCompleted select todo;//добавить вывод только для текущего дня недели
            return View(list);
        }
    }
}
