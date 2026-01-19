using Core_EF_Codefirst.Models;
using Core_EF_Codefirst.Services;
using Microsoft.EntityFrameworkCore;

namespace Core_EF_Codefirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //1. Add dbcontext and sql services
            builder.Services.AddDbContext<Emp_DeptContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CodeFirstConnection"));
            });
            builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employee}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
