using System;
using System.ComponentModel.DataAnnotations;

namespace CoursesApplication.Models.View
{
    public class CourseModel
    {
        [Required]
        [RegularExpression(@"[A-Za-zА-Яа-я]+", ErrorMessage = "Имя должно содержать либо латинские буквы, либо кирилицу")]
        [StringLength(50, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 3)]
        public String Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 3)]
        public String Description { get; set; }

        [Required]
        public Double Price { get; set; }

        [Required]
        public String DayOfWeek { get; set; }

        [Required]
        public TimeSpan TimeStart { get; set; }

        [Required]
        public TimeSpan TimeEnd { get; set; }
    }
}
