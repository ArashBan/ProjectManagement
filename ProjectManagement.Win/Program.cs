using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectManagement.Application.Services.Implementations;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.DataLayer.Context;
using ProjectManagement.DataLayer.Repository;
using ProjectManagement.Win.Tools;
using System;
using System.Windows.Forms;

namespace ProjectManagement.Win
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Calender.InitializePersianCulture();
            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
            System.Windows.Forms.Application.Run(ServiceProvider.GetRequiredService<MainForm>());
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainForm>();
                services.AddTransient<TeacherForm>();
                services.AddTransient<StudentForm>();
                services.AddTransient<ProjectAndInternshipForm>();
                services.AddTransient<ProjectDetailsForm>();
                services.AddTransient<InternshipDetailsForm>();
                services.AddTransient<QuestionForm>();
                services.AddTransient<LoginForm>();
                services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
                services.AddTransient<IStudentService, StudentService>();
                services.AddTransient<ITeacherService, TeacherService>();
                services.AddTransient<ICourseService, CourseService>();
                services.AddTransient<IUserService, UserService>();
                services.AddTransient<INotificationService, NotificationService>();
                services.AddTransient<IInternshipService, InternshipService>();
                services.AddTransient<IProblemService, ProblemService>();
                services.AddTransient<INewsService, NewsService>();
                services.AddTransient<IMainFormService, MainFormService>();
                services.AddDbContext<ProjectManagementContext>(x =>
                    x.UseSqlServer("Data Source=193.141.65.167,2019; Initial Catalog=ProjectManagementDb; Integrated Security=false; User Id=university_user; password=Twb6&o812; MultipleActiveResultSets=true"));
                //x.UseSqlServer("Data Source=.; Initial Catalog=ProjectManagementDb; Integrated Security=false; MultipleActiveResultSets=true"));
            });
        }
    }
}
