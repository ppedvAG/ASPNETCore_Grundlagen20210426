using Microsoft.AspNetCore.Mvc;
using MVCIntroductionSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCIntroductionSamples.Controllers
{
    public class BookController : Controller
    {
        private IList<Book> bookList = new List<Book>();
        //ctor + Tab + Tab
        public BookController()
        {
            bookList.Add(new Book() { Id = 1, Title = "Herr der Ringe", Description = "Fantasy Roman mit kleinen Hobbits", Autor = "Max und Moritz" });
            bookList.Add(new Book() { Id = 2, Title = "ES", Description = "nur für Erwachsene", Autor = "Steven King" });
            bookList.Add(new Book() { Id = 3, Title = "Der Heimweg", Description = "Deutschen Quantitätsthriller", Autor = "Fritzek" });
        }


        public IActionResult Index() //Get-Methoden
        {

            return View(bookList);
        }

        public IActionResult Details(int id) //Get-Methode
        {
            Book currentBook = bookList.Single(n => n.Id == id);
            return View(currentBook);
        }
    }
}
