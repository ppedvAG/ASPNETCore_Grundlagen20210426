using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StateManangementSample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StateManangementSample.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            //Entity Poco - Objekte
            Person person = new Person();
            person.id = 1;
            person.FirstName = "Max";
            person.LastName = "Mustermann";

            return View(person);
        }

        public IActionResult ViewDataSample2()
        {
            return View(/* Eigentlich können wir hier Daten an die UI übertragen*/);
        }


        public IActionResult SessionResult()
        {
            int? lottozahlen = HttpContext.Session.GetInt32("Lottozahlen");
            string lottogewinner = HttpContext.Session.GetString("Lottogewinnerin");


            string jsonString = HttpContext.Session.GetString("PersonObj");

            Person person = JsonSerializer.Deserialize<Person>(jsonString);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
