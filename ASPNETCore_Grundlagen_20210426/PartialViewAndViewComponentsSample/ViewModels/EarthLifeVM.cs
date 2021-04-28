using PartialViewAndViewComponentsSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewAndViewComponentsSample.ViewModels
{
    public class EarthLifeVM
    {
        public IList<Animal> AlleTiere { get; set; } = new List<Animal>();

        public IList<Humans> AllHumans { get; set; } = new List<Humans>();

        public EarthLifeVM()
        {

        }
    }
}
