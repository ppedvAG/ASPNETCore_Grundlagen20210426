using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultipleSubmitButtons.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleSubmitButtons.Controllers
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
            return View();
        }


        public IActionResult MultipleButtons1 ()
        {
            return View();
        }

        

        [HttpPost]
        public ActionResult ProcessForm(string submit)
        {
            switch (submit)
            {
                case "Save":
                    ViewBag.Message = "Customer saved successfully!";
                    break;
                case "Cancel":
                    ViewBag.Message = "The operation was cancelled!";
                    break;
            }
            return RedirectToAction("Index");
        }


        public IActionResult MultipleButtons2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveForm()
        {
            ViewBag.Message = "Customer saved successfully!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CancelForm()
        {
            ViewBag.Message = "The operation was cancelled!";
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
