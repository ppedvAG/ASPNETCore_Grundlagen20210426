using BookShop.Data;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public class BookService : IBookService
    {
        //private IList<Book> _context.Books = new List<Book>();

        private BookDbContext _context;

        public BookService(BookDbContext context)
        {
            _context = context;
        }


        public IList<Book> GetBooks(string query, bool onlyAudioBooks = false)
        {
            IList<Book> results;
            if (string.IsNullOrEmpty(query))
            {
                if (onlyAudioBooks)
                    results = _context.Books.Where(q => q.AudioBook == onlyAudioBooks).ToList(); //Anzeige der gesamten Audio

                else
                    results = _context.Books.ToList();

            }
            else
            {
                if (onlyAudioBooks)
                    results = _context.Books.Where(q => q.Title.Contains(query) && q.AudioBook == onlyAudioBooks).ToList();
                else
                    results = _context.Books.Where(q => q.Title.Contains(query)).ToList();
            }

            return results;
        }

        public Book GetById(Guid id)
        {
            return _context.Books.Where(n => n.ID == id).FirstOrDefault();
        }

        public int GetCount()
        {
            return _context.Books.Count();
        }

        public Book GetNewestPublishedBook()
        {
            if (_context.Books.Where(n => n.AudioBook == false).Count() == 0)
                return new Book();

            return _context.Books.Where(n => n.AudioBook == false).OrderByDescending(o => o.Published).First();
        }

        public Book GetNewestPublishedAudioBook()
        {
            if (_context.Books.Where(n => n.AudioBook == true).Count() == 0)
                return new Book();

            return _context.Books.Where(n => n.AudioBook == true).OrderByDescending(o => o.Published).First();
        }

        public Book InsertBook(Book book)
        {
            //Guid myID = Guid.Empty;

            //if (myID == Guid.Empty)
            //    myID = Guid.NewGuid();

            book.ID = Guid.NewGuid();
            _context.Books.Add(book);

            return book; 
        }


        public Book InsertBook(Book book, string pictureFullName)
        {
            book.ID = Guid.NewGuid(); //Simulation, dass SQL SErver mit eine ID vergibt. 
            book.PictureName = book.ID + pictureFullName;
            
            _context.Books.Add(book);
            //SaveChanges();
            return book;
        }
    }
}
