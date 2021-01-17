using CoursesApplication.Models.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoursesApplication.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task CreateAsync(Course model);
        Task UpdateAsync(Course model);
        Task DeleteAsync(String id);
    }
}
