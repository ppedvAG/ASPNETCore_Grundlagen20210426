using DISample.Better;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCIntroductionSamples.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCIntroductionSamples.Controllers
{


    //Aufgaben eines Controllers in MVC: 

    // - Gebe Daten von ServiceLayer oder Data-Access Layer an die UI weiter. 
    // - Nimmt Daten (Formular) von Browser entgegen, bewertet diese (Validierung) und reicht diese an ServiceLayer oder DataAccess Layer weiter
    // - Navigation zu anderen Controllern (Verlinkung) 


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICar _myMockCar;
        
        public HomeController(ILogger<HomeController> logger, ICar myCar)
        {
            _logger = logger;
            _myMockCar = myCar;
        }

        public IActionResult Index()
        {
            return View(_myMockCar); //Nehme Daten aus Service-Call oder EF-Query und gebe diese als Parameter in die View über
        }

        public IActionResult Privacy()
        {
            //Das ist böse, aber ich muss es zeigen

            //Bevor Privacy überhaupt angezeigt wird, leiten wir auf Index Home um. 
            //In Get-Methoden wird RedirectToAction ignoriert. 
            //RedirectToAction("Index", "Home"); //RedirectToAction ist eher in einer Post-Methode zu finden

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
