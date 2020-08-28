using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Models;
using Todo.Services;
using Todo.ViewModel;

namespace Todo.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    _userRepository.Create(
                        new User
                        {
                            Email = model.Email,
                            Password = model.Password,
                            Firstname = model.FirstName,
                            Lastname = model.LastName,
                            RegDate = DateTime.Today
                        });
                    await _userRepository.Authenticate(model.Email, HttpContext);
                    return RedirectToAction("Index", "Main");
                }

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
            if (ModelState.IsValid)
            {
                var user = await _userRepository.Users.FirstOrDefaultAsync(u =>
                    u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await _userRepository.Authenticate(model.Email, HttpContext);
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