namespace Middleware_Prj
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //to use custom webroot name, we have to use the applications options
            WebApplicationOptions webApplicationOptions = new WebApplicationOptions
            {
                WebRootPath = "MyWebRoot",
                Args = args,
                EnvironmentName = "Production",
            };
            var builder = WebApplication.CreateBuilder(webApplicationOptions);
            var app = builder.Build();

            //8. Adding static files middleware
              app.UseStaticFiles();

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
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("1st Middleware Request \n" );
            //    await next();
            //    await context.Response.WriteAsync("1st Middleware \n");

            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("2nd Middleware Request \n");
            //    await next();
            //    await context.Response.WriteAsync("2nd Middleware Response \n");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync(" 3rd Middleware Request and Response..\n");

            //});


            //7. Webapplication option class for changing any property values before create builder
            //app.MapGet("/", () => $"EnvironmentName {app.Environment.EnvironmentName} \n" +
            //$"ApplicationName :{app.Environment.ApplicationName} \n " +
            //$"WebRootPath :{app.Environment.WebRootPath} \n " +
            //$"ContentRootPath :{app.Environment.ContentRootPath}");
            app.Run();
        }

        private static async Task FirstMiddleware(HttpContext context)
        {
            await context.Response.WriteAsync("Getting Response from Defined First Middleware");
        }
    }
}
