using Core_DI_Prj.Models;

namespace Core_DI_Prj
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddMvc();  

            //adding application service to the container
            //builder.Services.Add(new ServiceDescriptor(typeof(IStudentRepository), typeof(StudentRepository),
            //    new StudentRepository()));  //by default singleton

            builder.Services.AddSingleton<IStudentRepository, StudentRepository>();

            var app = builder.Build();
            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );

          //  app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
