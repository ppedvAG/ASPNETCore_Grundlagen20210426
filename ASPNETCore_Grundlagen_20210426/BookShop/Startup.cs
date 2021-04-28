using BookShop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookShop.Middleware;
using BookShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSingleton<CommonLocalizationService>();
            services.AddScoped<IBookService, BookService>();

            services.AddSession();


            services.AddDbContext<BookDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("BooksDbContext")));



            services.AddLocalization(); //Mehrsprachigkeit aktivieren 
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("de"),
                    new CultureInfo("fr"),
                    new CultureInfo("es"),
                    new CultureInfo("ru"),
                    new CultureInfo("ja"),
                    new CultureInfo("ar"),
                    new CultureInfo("zh"),
                    new CultureInfo("en-GB")
                };

                options.DefaultRequestCulture = new RequestCulture("en-GB");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
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
            app.UseAuthentication();

            app.UseSession();
            AppDomain.CurrentDomain.SetData("BildVerzeichnis", env.WebRootPath);

            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(localizationOptions);

            app.MapWhen(context => context.Request.Path.ToString().Contains("imagegen"), subapp =>
            {
                subapp.UseThumbNailGen();
            });

           // var supportedCultures = new[]
           //{
           //      new CultureInfo("en-US"),
           //      new CultureInfo("es"),
           //  };
           // app.UseRequestLocalization(new RequestLocalizationOptions
           // {
           //     DefaultRequestCulture = new RequestCulture("en-US"),
           //     // Formatting numbers, dates, etc.
           //     SupportedCultures = supportedCultures,
           //     // Localized UI strings.
           //     SupportedUICultures = supportedCultures
           // });

            //Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{Monat=1}/{Year=2020}/");



                // Die Default Regel ist ganz unten
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");


                endpoints.MapRazorPages();
            });
        }
    }
}
