using BookShop.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            SeedDatabase(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void SeedDatabase(IHost host)
        {
            var scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                // ServiceProvider = IOC
                var context = scope.ServiceProvider.GetRequiredService<BookDbContext>();


                SeedData.Initialize(context);

                //InMemeory - Database
                //if (context.Database.EnsureCreated())
                //{
                //    try
                //    {
                //        SeedData.Initialize(context);
                //    }
                //    catch (Exception ex)
                //    {

                //    }
                //}
            }
        }
    }
}
