using System;
using CoursesApplication.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApplication.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(String returnUrl = null)
        {
            return View(new Login { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Login(Login model)
        {
            return View(model);
        }

        public IActionResult Logout()
        {
            return Redirect("Login");
        }
    }
}