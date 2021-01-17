using CoursesApplication.Interfaces.Repositories;
using CoursesApplication.Models.Configuration;
using CoursesApplication.Models.Database;
using CoursesApplication.Repositories.SQLQueries;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoursesApplication.Repositories.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly string _connectionString;

        public CourseRepository(IOptions<DatabaseConnection> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        public async Task CreateAsync(Course model)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                await db.ExecuteAsync(MSSQLQueries.CreateCourse, model);
            }
        }

        public async Task DeleteAsync(String id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                await db.ExecuteAsync(MSSQLQueries.RemoveCourses, new { Id = id });
            }
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<Course>(MSSQLQueries.GetCourses);
            }
        }

        public async Task UpdateAsync(Course model)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                await db.ExecuteAsync(MSSQLQueries.UpdateCourses, model);
            }
        }
    }
}
