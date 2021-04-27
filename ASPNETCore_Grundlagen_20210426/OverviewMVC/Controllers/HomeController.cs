using DISample.Better;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OverviewMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OverviewMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICar _myCar;
        public HomeController(ILogger<HomeController> logger, ICar myCarObj)
        {
            _logger = logger;
            _myCar = myCarObj;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Hallo von Index");
            return View();
        }

        public IActionResult Privacy()
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
