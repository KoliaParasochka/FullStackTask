using CoursesApplication.Models.Database;
using CoursesApplication.Models.View;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoursesApplication.Interfaces.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task CreateAsync(CourseModel model);
        Task UpdateAsync(CourseModel model);
        Task DeleteAsync(String id);
    }
}
