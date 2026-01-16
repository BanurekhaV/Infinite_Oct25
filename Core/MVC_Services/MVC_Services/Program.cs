namespace MVC_Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //adding services here
            //1. mvc services
            builder.Services.AddMvc();

            var app = builder.Build();

            //1. Enabling routing middleware to match the incoming request to our endpoints
            app.UseRouting();

            //map to the default controller route
            // app.MapDefaultControllerRoute();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

          //  app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
