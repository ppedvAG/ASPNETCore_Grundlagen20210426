using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPICourse.Models;

namespace WebAPICourse.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext (DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPICourse.Models.Blog> Blogs { get; set; }
        public DbSet<WebAPICourse.Models.Comment> Comments { get; set; }
    }
}
