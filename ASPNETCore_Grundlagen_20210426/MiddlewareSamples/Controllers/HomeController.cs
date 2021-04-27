using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiddlewareSamples.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareSamples.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var test = HttpContext;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //Get-Methode -> Server senden fertige HTML Seite an Browser
        public IActionResult PictureUpload() //https://localhost:12345/Home/PictureUpload
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //wird benötigt, wenn GET/Post MEthoden den selben NAmen besitzen. ValidateAntiForgeryToken hilft gegen Crossite Attacks
        
        public IActionResult PictureUpload(IFormFile datei)
        {
            FileInfo fileInfo = new FileInfo(datei.FileName);

            var speicherPfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\" + fileInfo.Name;

            using (var fs = new FileStream(speicherPfad, FileMode.Create))
            { 
                datei.CopyTo(fs);
            }

            return RedirectToAction("Index");
        }

        public IActionResult PictureGallery()
        {
            var pfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images";

            string[] Bilder = Directory.GetFiles(pfad);

            return View(Bilder);
        }


        public IActionResult PictureThumbNailGallery()
        {
            var pfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images";

            string[] Bilder = Directory.GetFiles(pfad);

            return View(Bilder);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
