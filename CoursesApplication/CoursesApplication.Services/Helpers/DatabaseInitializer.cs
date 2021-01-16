using CoursesApplication.Models.Constants;
using CoursesApplication.Models.Database;
using Microsoft.AspNetCore.Identity;

namespace CoursesApplication.Services.Helpers
{
    public static class DatabaseInitializer
    {
        public static void SeedData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRole(roleManager);
            SeedUser(userManager);
        }

        private static void SeedUser(UserManager<User> userManager)
        {
            if (userManager.FindByEmailAsync(DefaultUserData.EMAIL).Result == null)
            {
                User user = new User();
                user.UserName = DefaultUserData.EMAIL;
                user.Email = DefaultUserData.EMAIL;

                IdentityResult identityResult = userManager.CreateAsync(user, DefaultUserData.PASSWORD).Result;

                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, DefaultUserData.ROLE_NAME);
                }
            }
        }

        private static void SeedRole(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(DefaultUserData.ROLE_NAME).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = DefaultUserData.ROLE_NAME;

                IdentityResult identityResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
