using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ThumbNailGen
    {
        private readonly RequestDelegate _next;

        public ThumbNailGen(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string img = httpContext.Request.Query["img"][0];

            var pfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\" + img;

            if (!File.Exists(pfad))
                pfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\" + "Default.jpg";

            using (var sr = new FileStream(pfad, FileMode.Open))
            {
                //Bitmap ist von -> using System.Drawing;
                using (var image = new Bitmap(sr))
                {
                    // Wie groß soll konventiertes Bild sein
                    var resized = new Bitmap(300, 200);

                    using (var graphics = Graphics.FromImage(resized))
                    {
                        graphics.DrawImage(image, 0, 0, 300, 200);
                        var ms = new MemoryStream();

                        resized.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        
                        await httpContext.Response.Body.WriteAsync(ms.ToArray());
                    }
                }
            }
            //return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ThumbNailGenExtensions
    {
        public static IApplicationBuilder UseThumbNailGen(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ThumbNailGen>();
        }
    }
}
