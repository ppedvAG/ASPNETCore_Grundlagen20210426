using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISample.BadSample
{
    public class Car // Programmierer A benötigt 5 Tage
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ConstructionYear { get; set; }
    }


    public class CarService //Programmierer B benötigt 3 Tage
    {
        public void RepairCar (Car car)
        {
            //Repariere das Auto
        }
    }

    //Nachteile an dieser Lösung:
    // - harte Verdrahtung -> bei Erweiterung läuft es meist auf ein Refactoring hinaus
    // - Erschwertes paralleles Arbeiten


}
