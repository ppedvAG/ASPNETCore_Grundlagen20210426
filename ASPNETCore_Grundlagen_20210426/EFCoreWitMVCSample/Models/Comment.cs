using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreWitMVCSample.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime CreateAt { get; set; }
        
        //FK - Spalte
        public int BlogId { get; set; }

        //Navigationsobjekt 
        public Blog Blog { get; set; }
    }
}
