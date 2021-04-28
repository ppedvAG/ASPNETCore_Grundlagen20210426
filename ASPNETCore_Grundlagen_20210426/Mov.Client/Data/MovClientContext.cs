using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie.Domain;

namespace Mov.Client.Data
{
    public class MovClientContext : DbContext
    {
        public MovClientContext (DbContextOptions<MovClientContext> options)
            : base(options)
        {
        }

        public DbSet<Movie.Domain.Movie> Movie { get; set; }
    }
}
