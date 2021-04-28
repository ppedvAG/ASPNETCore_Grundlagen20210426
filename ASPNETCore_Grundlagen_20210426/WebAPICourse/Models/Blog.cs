using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICourse.Models
{
    public class Blog
    {

        //EF arbeitet mit Koventionen und erkennt die Id/ID/id Spalte als PK 


        public int Id { get; set; }


        [Required(ErrorMessage = "Bitte gebe einen Titel an")]
        public string Title { get; set; }

        [MinLength(20)]
        public string Content { get; set; }

        public DateTime Created { get; set; }

        //Navigation 1:n ...

        public ICollection<Comment> Comments { get; set; }
    }
}
