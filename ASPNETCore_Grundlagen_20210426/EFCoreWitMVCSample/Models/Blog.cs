using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreWitMVCSample.Models
{
    public class Blog
    {

        //EF arbeitet mit Koventionen und erkennt die Id/ID/id Spalte als PK 
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public DateTime Created { get; set; }

        //Navigation 1:n ...

        public ICollection<Comment> Comments { get; set; }
    }
}
