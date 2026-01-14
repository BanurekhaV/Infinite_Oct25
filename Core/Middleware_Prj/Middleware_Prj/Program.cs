namespace Middleware_Prj
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            //1. understanding route patterns

            //app.MapGet("/greet", () => "Hello from /greet endpoint");

            //app.MapGet("/greet/{name}",(string name) =>$"Welcome, {name}!");

            //2. configure middleware and execute using run

            //app.Run(async (context)=>
            //{
            //    await context.Response.WriteAsync("Getting Response from First Middleware");
            //});

            //3. calling a seperate defined middleware 
            //app.Run(FirstMiddleware);

            //4. problem of multiple middlewares with run()
            //4.1 the below is 1st middleware
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Getting Response from First Middleware");
            //});

            ////4.2 second middleware
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Getting Response from Second Middleware");
            //});

            //5. to apply use() extension to solve the multiple middleware issues
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Started First Middleware .." + "<br>");
            //    await next();
            //    //context.Response.WriteAsync("Returning First from First Middleware");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Started Second Middleware .." + "<br>");
            //});

            //6. configuring chain of middlewares and calling with use extension
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Response from 1st Middleware" );
                await next();
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Response from 2nd Middleware");
                await next();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Response from 3rd Middleware");
               
            });

            app.Run();
        }

        private static async Task FirstMiddleware(HttpContext context)
        {
            await context.Response.WriteAsync("Getting Response from Defined First Middleware");
        }
    }
}
