using CoursesApplication.Interfaces.Services;
using CoursesApplication.Models.Configuration;
using CoursesApplication.Models.Database;
using CoursesApplication.Repositories.ApplicationContexts;
using CoursesApplication.Services.Account;
using CoursesApplication.Services.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace CoursesApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ServiceProvider serviceProvider;

            AddConnectionSettings(services);

            serviceProvider = services.BuildServiceProvider();

            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseSqlServer(serviceProvider.GetRequiredService<IOptions<DatabaseConnection>>().Value.ConnectionString);
            });

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            services.AddTransient<IdentityContext>();
            services.AddTransient<IUserService, UserService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            DatabaseInitializer.SeedData(userManager, roleManager);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void AddConnectionSettings(IServiceCollection service)
        {
            service.Configure<DatabaseConnection>(Configuration.GetSection("DatabaseConnection"));
        }

        private IConfiguration Configuration { get; set; }
    }
}
