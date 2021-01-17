using CoursesApplication.Models.View;
using System;
using System.Threading.Tasks;

namespace CoursesApplication.Interfaces.Services
{
    public interface IUserService
    {
        Task<Boolean> SignIn(Login model);
        Task SignOutUser();
    }
}
