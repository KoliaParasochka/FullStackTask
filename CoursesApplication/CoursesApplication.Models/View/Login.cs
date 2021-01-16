using System;
using System.ComponentModel.DataAnnotations;

namespace CoursesApplication.Models.View
{
    public class Login
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String Password { get; set; }

        public String ReturnUrl { get; set; }
    }
}
