using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoursesApplication.Interfaces.Services;
using CoursesApplication.Models.Database;
using CoursesApplication.Models.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApplication.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICourseService _courseService;

        public HomeController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Course> courses = await _courseService.GetAllAsync();

            ViewBag.Courses = courses;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseModel model)
        {
            if (ModelState.IsValid)
            {
                await _courseService.CreateAsync(model);
            }

            return Redirect("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(String id)
        {
            await _courseService.DeleteAsync(id);
            return Redirect("Index");
        }
    }
}
