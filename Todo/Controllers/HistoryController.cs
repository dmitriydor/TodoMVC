using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Services;

namespace Todo.Controllers
{
    public class HistoryController:Controller
    {
        private ITodoItemManager _todoItemManager;
        public HistoryController(ITodoItemManager todoItemManager)
        {
            _todoItemManager = todoItemManager;
        }
        public IActionResult Index()
        {
            return View(_todoItemManager.TodoItems.OrderBy(t=>t.Date).AsEnumerable());
        }
    }
}
