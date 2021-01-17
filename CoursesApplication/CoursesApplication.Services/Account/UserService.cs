using CoursesApplication.Interfaces.Services;
using CoursesApplication.Models.Database;
using CoursesApplication.Models.View;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace CoursesApplication.Services.Account
{
    public class UserService : IUserService
    {
        private readonly SignInManager<User> _signInManager;

        public UserService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Boolean> SignIn(Login model)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            return result.Succeeded;
        }

        public async Task SignOutUser()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
