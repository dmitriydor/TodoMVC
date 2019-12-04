using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Controllers
{
    public class MainController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
