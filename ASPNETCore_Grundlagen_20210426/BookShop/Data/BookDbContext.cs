using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Data
{
    public class BookDbContext : DbContext
    {

        public BookDbContext(DbContextOptions<BookDbContext> options)
            :base(options)
        {
                
        }

        public DbSet<Book> Books { get; set; }
    }
}
