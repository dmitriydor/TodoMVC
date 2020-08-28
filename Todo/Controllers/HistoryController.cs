using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Todo.Services;

namespace Todo.Controllers
{
    public class HistoryController : Controller
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public HistoryController(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public IActionResult Index()
        {
            return View(_todoItemRepository.TodoItems.OrderBy(t => t.Date).AsEnumerable());
        }
    }
}