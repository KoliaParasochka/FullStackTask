using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoursesApplication.Interfaces.Repositories;
using CoursesApplication.Interfaces.Services;
using CoursesApplication.Models.Database;
using CoursesApplication.Models.View;
using CoursesApplication.Services.Mappers;

namespace CoursesApplication.Services.Courses
{
    public class CourseService : ICourseService
    {
        public readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository repository)
        {
            _courseRepository = repository;
        }

        public async Task CreateAsync(CourseModel model)
        {
            Course course = CourseMapper.MapCourseModelToCourse(model);
            course.Id = new Guid().ToString();

            await _courseRepository.CreateAsync(course);
        }

        public async Task DeleteAsync(String id)
        {
            await _courseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public Task UpdateAsync(CourseModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
