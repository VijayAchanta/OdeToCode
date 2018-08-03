using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToCode.Services;

namespace OdeToCode
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            IGreeter greeter,
            ILogger<Startup> logger)
            //IConfiguration configuration)   
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                // throw new Exception("Error !!!");
                //var greeting = configuration["Greeting"];
                var greeting = greeter.GetMessageOfTheDay();
                //await context.Response.WriteAsync($"{greeting} : {env.EnvironmentName}");
                //context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Not Found");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //  Default route /home/index/4

            routeBuilder.MapRoute("default",
                "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
// -----------------------------------------------------------
//app.Use(next =>
//{
//    return async context =>
//    {
//        logger.LogInformation("Request Incoming");
//        if (context.Request.Path.StartsWithSegments("/mym"))
//        {
//            await context.Response.WriteAsync("Hit !!!");
//            logger.LogInformation("Request handled");
//        }
//        else
//        {
//            await next(context);
//            logger.LogInformation("Response Outgoing.");
//        }
//    };
//});

//app.UseWelcomePage(new WelcomePageOptions
//{
//    Path = "/wp"
//});

//app.UseDefaultFiles();
//app.UseStaticFiles();
//app.UseFileServer();
// -----------------------------------------------------------

