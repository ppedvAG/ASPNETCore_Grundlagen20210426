using StateManangementSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateManangementSample.ViewModels
{
    public class PersonVM
    {
        //Variablen aus Person oder sogar ein Person-Object
        public Person Employee { get; set; }

        int Urlaubstage { get; set; }

        public Person PersonAnsprechPartner { get; set; }
        
    }
}
