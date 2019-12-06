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
    public class MainController:Controller
    {
        private ITodoItemManager _context;
        public MainController(ITodoItemManager context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<TodoItem> list = _context.TodoItems.ToList();
            return View(list);
        }
    }
}
