namespace WebApp_Core1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //creating the web Host and services
            var builder = WebApplication.CreateBuilder(args);

            //building the application
            var app = builder.Build();

            //setting up endpoints, routing and middleware component
            //app.MapGet("/", () => "Hello and welcome to ASP.Net Core!" + 
            //1.//System.Diagnostics.Process.GetCurrentProcess().ProcessName);

            //2. read config info
            string? Ourkeyvalue = builder.Configuration.GetValue<string>("OurNewKey","default");

            //get the configuration value
            string? keyval = builder.Configuration["OurNewKey"];

            app.MapGet("/", () => $"{keyval}");

            app.Run();
        }
    }
}
