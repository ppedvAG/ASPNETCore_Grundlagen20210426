using ConfigurationsWithDISample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration; // IConfiguration
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationsWithDISample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly SampleWebSettings _settings;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IOptions<SampleWebSettings> settingOptions)
        {
            _logger = logger;
            _configuration = configuration;

            //Für Beispiel2 - seperate Configuration.json
            //_settings = (SampleWebSettings)settingOptions;

            _settings = settingOptions.Value;
        }


        //https:localhost:12345/Home/Index     Variante B: Eingabe-> localhost:12345 -> https:localhost:12345/Home/Index
        [HttpGet]
        public IActionResult Index() //Ist eine GET-Action Methode
        {
            PositionOptions positionOptions = new PositionOptions();
            _configuration.GetSection(PositionOptions.Position).Bind(positionOptions);

            Debug.WriteLine(positionOptions.Name);
            Debug.WriteLine(positionOptions.Title);
            return View();
        }

        [HttpGet]
        //https:localhost:12345/Home/Privacy
        public IActionResult Privacy() // Ist eine Get-Methode
        {
            return View();
        }

        //[HttpPost] ist ein HTTP-Verb
        [HttpPost] //definiert, dass eine "Action-Methode" eine Post-Methode ist
        public IActionResult MyFirstPost(/*verwendet meist eine objektstruktur als Parameter */)
        {
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
