using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;
using Todo.Services;
using Todo.ViewModel;

namespace Todo.Controllers
{
    public class AccountController:Controller
    {
        private IUserManager _userManager;
        public AccountController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Registration ()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    _userManager.Create(
                        new User {
                            Email = model.Email, 
                            Password = model.Password,
                            Firstname = model.FirstName,
                            Lastname = model.LastName,
                            RegDate = DateTime.Today
                        });
                    await _userManager.Authenticate(model.Email, this.HttpContext);
                    return RedirectToAction("Index", "Main");
                }
                else
                    ModelState.AddModelError("", "Such user exists");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                User user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await _userManager.Authenticate(model.Email, HttpContext);
                    return RedirectToAction("Index", "Main");
                }
                ModelState.AddModelError("", "Incorrect email or password");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult EditUser(string email)
        {
            return BadRequest();
        }
        [HttpPost]
        public IActionResult EditUser(User user)
        {
            return BadRequest();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
