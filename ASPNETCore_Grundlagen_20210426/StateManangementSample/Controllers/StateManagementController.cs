using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StateManangementSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StateManangementSample.Controllers
{   //Beispielübersicht
    //ViewData / ViewBag - TempData / Session
    public class StateManagementController : Controller
    {
        public IActionResult ViewDataSample()
        {
            ViewData["abc"] = "Hallo liebe Teilnehner";
            ViewData["def"] = "Das Wetter ist heute schön";

            return View(/* Eigentlich können wir hier Daten an die UI übertragen*/);
        }

        public IActionResult ViewDataSample2()
        {
            ViewData["abc"] = "Hallo liebe Teilnehner";
            ViewData["def"] = "Das Wetter ist heute schön";

            
            return View(/* Eigentlich können wir hier Daten an die UI übertragen*/);
        }

        public IActionResult ViewBagSample()
        {
            ViewBag.CBA = "Hallo liebe Teilnehmer";
            ViewBag.Wetter = "Die Sonne scheint";
            
            return View(/* Eigentlich können wir hier Daten an die UI übertragen*/);
        }


        public IActionResult TempDataSample1()
        {
            TempData["abc"] = "Hallo liebe Teilnehmer";
            TempData["id"] = 123;

            return View();
        }
        public IActionResult TempDataSample2()
        {
            return View();
        }
        public IActionResult TempDataSample3()
        {
            return View();
        }

        public IActionResult SessionInit()
        {
            HttpContext.Session.SetInt32("Lottozahlen", 1234567);
            HttpContext.Session.SetString("Lottogewinnerin", "Heike Musterfrau");


            Person person = new Person();
            person.id = 1;
            person.FirstName = "R2D2";
            person.LastName = "Skywalker";

            string jsonString = JsonSerializer.Serialize(person);
            HttpContext.Session.SetString("PersonObj", jsonString);


            return View();
        }

    }
}
