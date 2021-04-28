using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Data
{
    public class SeedData
    {
        public static void Initialize(BookDbContext context)
        {
            // Wenn Tabelle Leer ist
            if (!context.Books.Any())
            {
                context.Books.Add(new Book { ID = Guid.NewGuid(), Title = "Heimweg", Author = "Fritzek", Price = 10.99m, Published = new DateTime(2020, 12, 05) });
                context.Books.Add(new Book { ID = Guid.NewGuid(), Title = "The Green Mile", Author = "Steven King", Price = 9.99m, Published = new DateTime(1988, 7, 05) });
                context.Books.Add(new Book { ID = Guid.NewGuid(), Title = "ASP.NET WebForms", Author = "Hannes Preishuber", Price = 49.95m, Published = new DateTime(1989, 9, 05) });
                context.Books.Add(new Book { ID = Guid.NewGuid(), Title = "Ein verheißenes Land", Author = "Obama", Price = 49.95m, Published = new DateTime(2020, 9, 05) });
                context.Books.Add(new Book { ID = Guid.NewGuid(), Title = "Ohne Schuld", Author = "Charlotte Link", Price = 19.99m, Published = new DateTime(2018, 5, 4) });
                context.Books.Add(new Book { ID = Guid.NewGuid(), Title = "Ostfriesenzorn", Author = "Klaus-Peter Wolf", Price = 10.99m, AudioBook = true, Published = new DateTime(1988, 5, 4) });
                context.Books.Add(new Book { ID = Guid.NewGuid(), Title = "Arbeitsweg", Author = "Fritzek", Price = 20m, Published = new DateTime(1987, 5, 4) });
                context.Books.Add(new Book { ID = Guid.NewGuid(), Title = "Westfriesenlieb", Author = "Klaus-Peter Wolf", Price = 9.99m, Published = new DateTime(1987, 5, 4) });
                context.Books.Add(new Book { ID = Guid.NewGuid(), Title = "Ostfriesenmelodie", Author = "Klaus-Peter Wolf", Price = 9.99m, Published = new DateTime(1999, 6, 4) });
                context.Books.Add(new Book { ID = Guid.NewGuid(), Title = "Coding des Schreckens - Ein JavaScript Rundumblick", Author = "Kevin Winter", Price = 8.99m, AudioBook = true, Published = new DateTime(2021, 3, 1) });
                context.Books.Add(new Book { ID = Guid.NewGuid(), Title = "Relaxed Yoga", Author = "Wiebkle Roland", Price = 12.99m, Published = new DateTime(2020, 5, 4) });
                context.Books.Add(new Book { ID = Guid.NewGuid(), Title = "Der neunte Arm des Oktopus", Author = "Rossmann", Price = 19.99m, AudioBook = true, Published = new DateTime(2019, 5, 4) });

                context.SaveChanges();
            }
        }
    }
}
