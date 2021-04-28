using BookShop.Models;
using BookShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookShop.Controllers
{
    public class OrderController : Controller
    {
        private IBookService _service;

        public OrderController(IBookService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            IList<Book> books = new List<Book>();
            if (HttpContext.Session.IsAvailable)
            {
                if (HttpContext.Session.Keys.Contains("ShoppingCart"))
                    books = InitializeShoppingCarts();
            }

            return View(books);
        }

        private IList<Book> InitializeShoppingCarts()
        {
            IList<Book> shoppingCarts = new List<Book>();

            string shoppingCartJson = HttpContext.Session.GetString("ShoppingCart");
            List<Guid> idList = JsonSerializer.Deserialize<List<Guid>>(shoppingCartJson);

            Book book = null;

            foreach (Guid currentArticleId in idList)
            {
                book = new Book();
                book = _service.GetById(currentArticleId);
                shoppingCarts.Add(book);
            }

            return shoppingCarts;
        }


        
        [HttpPost] 
        public IActionResult Cancel(Guid? id)
        {
            if (!id.HasValue)
                throw new ArgumentException();

            IList<Book> shoppingCart = new List<Book>();
            shoppingCart = InitializeShoppingCarts();

            if (shoppingCart.Any(a => a.ID == id.Value))
            {
                Book toCancel = shoppingCart.First(a => a.ID == id.Value);
                shoppingCart.Remove(toCancel);
            }

            if (shoppingCart.Count() == 0)
                HttpContext.Session.Remove("ShoppingCart");
            else
            {
                string jsonString = JsonSerializer.Serialize(shoppingCart.Select(n => n.ID).ToList());
                HttpContext.Session.SetString("ShoppingCart", jsonString);
            }


            return RedirectToAction("Index");
        }



        public IActionResult Payment()
        {
            return View();
        }
    }
}
