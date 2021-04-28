using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewAndViewComponentsSample.Models
{
    public class Humans
    {
        public int Id { get; set; }
        public Gender Gender { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        
    }

    public enum Gender { woman=0, man, others}
}
