using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISample.Better
{
    public interface ICar
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ConstructYear { get; set; }
    }

    public interface ICarService
    {
        void RepairCar(ICar car);
    }



    public class Car : ICar // Programmierer A benötigt 5 Tage
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ConstructYear { get; set; }
    }

    public class CarService : ICarService // Programmierer B benötigt 3 Tage
    {
        public void RepairCar(ICar car) //<- wird verwenden hier ein Interface 
        {
           //Repariere das Fahrzeug
        }
    }

    public class MockCar : ICar
    {
        public string Brand { get; set; } = "VW";
        public string Model { get; set; } = "Polo";
        public DateTime ConstructYear { get; set; } = DateTime.Now;
    }

}
