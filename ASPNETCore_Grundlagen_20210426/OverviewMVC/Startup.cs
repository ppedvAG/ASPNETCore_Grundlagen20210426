using DISample.Better;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverviewMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration) //IConfiguration = Appsetting.json Handler
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //IOC - Container
        {
            services.AddControllersWithViews(); //Verwende den MVC Ansatz
                                                //Konvention -> Benutze die Verzeichnisse "Controller" / "Views" / "Models"

            services.AddSingleton<ICar, MockCar>();
            //services.AddSingleton<ICar, Car>(); //Objekt Car w�rde Objekt MockCar �berschreiben

            //services.AddTransient<ICar, MockCar>();
            //services.AddScoped<ICar, MockCar>();
            //services.AddSingleton(typeof(ICar), typeof(MockCar)); //weitere Variante


            //services.AddControllers(); //Verwende noch zus�tzlich die WebAPI 
            //Konventionen, verwende Controller ODER Controller\api\
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //Variante f�r Entwickler. Bekommen z.b eine Detailierte Fehlermeldung
                app.UseDeveloperExceptionPage(); 
            }
            else 
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
