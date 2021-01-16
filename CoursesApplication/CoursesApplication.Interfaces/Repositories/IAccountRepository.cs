using CoursesApplication.Models.View;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CoursesApplication.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityUser> SingInAsync(Login model);

        Task<IdentityUser> SingOutAsync();
    }
}
