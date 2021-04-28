using System;

namespace Movie.Domain
{
    public class Movie
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
