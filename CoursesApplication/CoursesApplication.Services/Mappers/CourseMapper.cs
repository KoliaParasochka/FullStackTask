
using CoursesApplication.Models.Database;
using CoursesApplication.Models.View;

namespace CoursesApplication.Services.Mappers
{
    static class CourseMapper
    {
        public static Course MapCourseModelToCourse(CourseModel model)
        {
            return new Course
            {
                Name = model.Name,
                Description = model.Description,
                DayOfWeek = model.DayOfWeek,
                Price = model.Price,
                TimeEnd = model.TimeEnd,
                TimeStart = model.TimeStart
            };
        } 
    }
}
