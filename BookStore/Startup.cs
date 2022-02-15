using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            /*app.Use(async (contex, next) =>
            {
                await contex.Response.WriteAsync("my first middleware");
                await next();
            });
            
            app.Use(async (contex, next) =>
            {
                await contex.Response.WriteAsync("My Second Middleware");
                await next();
            });

            app.Use(async (contex, next) =>
            {
                await contex.Response.WriteAsync("My Third Middleware");
            }); 

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => 
                {
                    await context.Response.WriteAsync(env.EnvironmentName);
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/Product", async context =>
                {
                    await context.Response.WriteAsync("hello Form Product");
                });
            }); */

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
