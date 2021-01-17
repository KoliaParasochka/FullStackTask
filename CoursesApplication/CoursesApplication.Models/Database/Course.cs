using System;

namespace CoursesApplication.Models.Database
{
    public class Course
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String DayOfWeek { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
        public Double Price { get; set; }
    }
}
