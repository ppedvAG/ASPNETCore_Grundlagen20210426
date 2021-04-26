using DISample.Better;
using Microsoft.Extensions.DependencyInjection; //ServiceCollection
using System;

namespace ServiceCollectionAndServiceProviderSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection(); //Reisetasche (IOC-Container)

            serviceCollection.AddSingleton<ICar, MockCar>(); // Befüllung der Reisetasche
            
            
            ServiceProvider provider = serviceCollection.BuildServiceProvider(); //Reisetasche wird hier zugeschnürrt

            //Dezentraler Zugriff auf IOC Container = Seperation of Concerne
            ICar mockCar = provider.GetRequiredService<ICar>(); //Aus der Reisetasche wird folgene Instance zurück gegeben

            Console.ReadLine();
        }
    }
}
