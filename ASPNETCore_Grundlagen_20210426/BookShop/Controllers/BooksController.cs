using BookShop.Models;
using BookShop.Services;
using BookShop.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookShop.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        //ctor + tab + tab -> Konstruktor
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }




        //Route("Kevin/Details/{id:int}")]
        //public IActionResult Details(int id)
        //{
        //    return View();
        //}


        //[Route("Kevin/Details2/{id:int?}")]
        //public IActionResult Details2(int id)
        //{
        //    return View();
        //}


        [Route("Kevin/Index2")]

        public IActionResult Index(string query, bool audioBook=false) // Get - Methode
        {
            BooksVM booksVM = new(); //C# 9.0 BooksVM booksVM = new BooksVM()

            booksVM.Books = _bookService.GetBooks(query, audioBook);
            booksVM.NewestPublishedBook = _bookService.GetNewestPublishedBook();
            booksVM.NewestPublishedAudioBook = _bookService.GetNewestPublishedAudioBook();

            return View(booksVM);
            //return View(_bookService.GetBooks(string.Empty, false));
        }

        public IActionResult Details(Guid? id)
        {
            if (!id.HasValue)
                return NotFound();

            Book book = _bookService.GetById(id.Value);

            if (book == null)
                return NotFound();


            return View(book);
        }

        //Get Methode
        [HttpGet]
        public IActionResult Create()
        {
            return View(); //In .NET Framework 4.8 - return View (new Book());
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormFile datei, Book book)
        {
            //if (book.Price < 20)
                //ModelState.AddModelError("Preisfestlegung", "Der Preis muss mindestens über 20 Euro liegen");

            if (ModelState.IsValid)
            {
                //Rückgegebenes Buch wird die ID benötigt, damit da ein Bildname gemappt wird. 
                book = _bookService.InsertBook(book); // DB Save

                FileInfo fileInfo = new FileInfo(datei.FileName);
                book.PictureName = book.ID.ToString() + fileInfo.Extension;
                

                //Festlegen des Zielverzeichnisses
                var pfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\" + book.PictureName;

                using (var fs = new FileStream(pfad, FileMode.Create))
                    datei.CopyTo(fs);

            }
            else
                return View(book);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Buy (Guid? id)
        {
            if (!id.HasValue)
                throw new ArgumentException();

            if (HttpContext.Session.IsAvailable)
            {
                List<Guid> idList = new List<Guid>();


                // Wenn Waren schon im Einkaufskorb sich befinden. muss der warenkorb als Objekt aufgelöst werden, damit wir "neue" Käufe hinzufügen können
                if (HttpContext.Session.Keys.Contains("ShoppingCart"))
                {
                    string jsonIdList = HttpContext.Session.GetString("ShoppingCart");

                    idList = JsonSerializer.Deserialize<List<Guid>>(jsonIdList);
                }

                idList.Add(id.Value);

                string jsonString = JsonSerializer.Serialize(idList);

                HttpContext.Session.SetString("ShoppingCart", jsonString);
            }
            return RedirectToAction("Index");
        }

        #region Partial with jQuery
        public IActionResult OnGetNewestBookPartial() =>
            new PartialViewResult
            {
                ViewName = "_NewestBookPartial",
                ViewData = ViewData,
            };

        public IActionResult GetNewestAudioBookPartial() =>
            new PartialViewResult
            {
                ViewName = "_NewestAudioBookPartial",
                ViewData = ViewData,
            };
        #endregion
    }
}
