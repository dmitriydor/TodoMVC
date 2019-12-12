using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Services;

namespace Todo.Controllers
{
    public class AccountController:Controller
    {
        private IUserManager _userManager;
        public AccountController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Registration ()
        {
            return BadRequest();
        }

        public IActionResult Login()
        {
            return BadRequest();
        }
        public IActionResult EditUser()
        {
            return BadRequest();
        }
    }
}
