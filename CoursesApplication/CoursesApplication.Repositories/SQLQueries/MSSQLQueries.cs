
namespace CoursesApplication.Repositories.SQLQueries
{
    public static class MSSQLQueries
    {
        public static string GetCourses => @"
                SELECT 
                    Id,
                    Name,
                    Description,
                    DayOfWeek,
                    TimeStart,
                    TimeEnd,
                    Price
                FROM Course";

        public static string CreateCourse => @"
                INSERT INTO Course ( 
                    Id,
                    Name,
                    Description,
                    DayOfWeek,
                    TimeStart,
                    TimeEnd,
                    Price)
                VALUES (
                    @Id,
                    @Name,
                    @Description,
                    @DayOfWeek,
                    @TimeStart,
                    @TimeEnd,
                    @Price
                )";

        public static string RemoveCourses => @"
                DELETE FROM Course
                    WHERE Id = @Id";

        public static string UpdateCourses => @"
                UPDATE Course
                    SET
                        Name = @Name,
                        Description = @Description,
                        DayOfWeek = @DayOfWeek,
                        TimeStart = @TimeStart,
                        TimeEnd = @TimeEnd,
                        Price = @Price
                    WHERE Id = @Id";
    }
}
