using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using MiddlewareSamples.Middleware;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Westwind.AspNetCore.LiveReload;

namespace MiddlewareSamples
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddLiveReload(config =>
            {
                // optional - use config instead
                //config.LiveReloadEnabled = true;
                //config.FolderToMonitor = Path.GetFullname(Path.Combine(Env.ContentRootPath,"..")) ;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseLiveReload();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();
           // app.UseResponseCompression(); // Response von Static sind Files sind konprimiert -> 

            app.UseRouting();

            app.UseAuthorization();


            #region CustomMiddlewares 


            #region Beispiel - Verkettung einer Pipeline mithilfe von Custom-Middleware
            //Inline Middleware

            //Use - Middleware verwendet ein next(), ohne next(), wäre die Middleware auch terminiert. 
            //app.Use(async (context, next) =>
            //{
            //    //await context.Response.WriteAsync("Before Invoke from 1st app.Use\n");
            //    await next(); //Calle nächste Middleware
            //    //await context.Response.WriteAsync("After Invoke from 1st app.Use()\n");
            //});

            //Use - Middleware verwendet ein next(), ohne next(), wäre die Middleware auch terminiert. 
            //app.Use(async (context, next) =>
            //{
            //    //await context.Response.WriteAsync("Before Invoke from 2nd app.Use\n");
            //    await next();
            //    //await context.Response.WriteAsync("After Invoke from 2nd app.Use()\n");
            //});


            //Mit Run kann man terminierte Middlewares erstellen
            //app.Run(async (context) =>
            //{
            //    await context.Connection.GetClientCertificateAsync();
            //});

            ////Dieser Code wird nie ausgeführt
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello from 2st app.Run");
            //});
            #endregion

            #region Beispiel mit Map
            ////Request                         Response
            ////https://localhost:44362/        Hello from app.Run()
            ////https://localhost:44362/m1      Hello from 1st app.Map()
            ////https://localhost:44362/m1/xyz  Hello from 1st app.Map()
            ////https://localhost:44362/m2      Hello from 2nd app.Map()
            ////https://localhost:44362/m500    Hello from app.Run()

            //app.Map("/m1", HandleMapOn);
            //app.Map("/m2", appMap =>
            //{
            //    appMap.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("Hello from 2nd app.Mapp()");
            //    });
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello from app.Run()");
            //});

            #endregion

            //Beispiel 3 - DirectoryBrowser
            //app.UseDirectoryBrowser(new DirectoryBrowserOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
            //    RequestPath = "/images"
            //}) ;

            #endregion

            AppDomain.CurrentDomain.SetData("BildVerzeichnis", env.WebRootPath);
            
            //Middleware wird aufgerufen, wenn imagegen in einem Request erkannt wird
            app.MapWhen(context => context.Request.Path.ToString().Contains("imagegen"), subapp =>
            {
                subapp.UseThumbNailGen();
            });

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void HandleMapOn(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from 1st app.Map()");
            });
        }
    }
}
