using System;
using System.Threading.Tasks;
using CoursesApplication.Interfaces.Services;
using CoursesApplication.Models.View;
using CoursesApplication.Services.Account;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApplication.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login(String returnUrl = null)
        {
            return View(new Login { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            Boolean result = false;
            ViewBag.ErrorMsg = String.Empty;

            if (ModelState.IsValid)
            {
                result = await _userService.SignIn(model);

                if (result)
                {
                    return Redirect("~/Home/Index");
                }

                ViewBag.ErrorMsg = "Operation failed!";
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.SignOutUser();

            return Redirect("Login");
        }
    }
}