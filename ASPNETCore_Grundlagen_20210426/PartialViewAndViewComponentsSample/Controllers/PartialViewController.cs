using Microsoft.AspNetCore.Mvc;
using PartialViewAndViewComponentsSample.Models;
using PartialViewAndViewComponentsSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewAndViewComponentsSample.Controllers
{
    public class PartialViewController : Controller
    {
        public IActionResult Index()
        {
            EarthLifeVM earthVM = new EarthLifeVM();

            earthVM.AlleTiere.Add(new Animal { Id = 1, Name = "Hund" });
            earthVM.AlleTiere.Add(new Animal { Id = 2, Name = "Katze" });
            earthVM.AlleTiere.Add(new Animal { Id = 3, Name = "Maus" });

            earthVM.AllHumans.Add(new Humans { Id = 1, Gender = Gender.woman, Birthday = DateTime.Now, Name = "Monika Muster" });
            earthVM.AllHumans.Add(new Humans { Id = 2, Gender = Gender.man, Birthday = DateTime.Now, Name = "Max Muster" });
            earthVM.AllHumans.Add(new Humans { Id = 3, Gender = Gender.others, Birthday = DateTime.Now, Name = "David Muster" });
            return View(earthVM);
        }
    }
}
