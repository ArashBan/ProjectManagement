using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Services.Implementations;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Application.Utils;
using ProjectManagement.DataLayer.Context;
using ProjectManagement.DataLayer.Repository;
using ShopManagement.Configuration.Permissions;

namespace ProjectManagement.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region Authentication

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LoginPath = "/login";
                options.LogoutPath = "/log-out";
                options.AccessDeniedPath = new PathString("/PageNotFound");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
            });

            //builder.Services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("AdminArea",
            //        builder => builder.RequireRole(new List<string> { "2" }));
            //});

            #endregion


            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddProgressiveWebApp();
            //builder.Services.AddRazorPages()
            //    .AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
            //    .AddRazorPagesOptions(options =>
            //    {
            //        options.Conventions.AuthorizeAreaFolder("Teacher", "/", "AdminArea");
            //    }).AddNewtonsoftJson();


            #region Config DataBase

            builder.Services.AddDbContext<ProjectManagementContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration
                        .GetConnectionString("ProjectManagementConnection"));
                });

            #endregion

            #region Config Services

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddTransient<IStudentService, StudentService>();
            builder.Services.AddTransient<ITeacherService, TeacherService>();
            builder.Services.AddTransient<ICourseService, CourseService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<INotificationService, NotificationService>();
            builder.Services.AddTransient<IInternshipService, InternshipService>();
            builder.Services.AddTransient<IProblemService, ProblemService>();
            builder.Services.AddTransient<INewsService, NewsService>();
            builder.Services.AddTransient<IProfileService, ProfileService>();

            #endregion

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}