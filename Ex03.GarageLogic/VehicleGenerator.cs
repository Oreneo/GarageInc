using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleGenerator
    {
        List<Vehicle> Vehicles = new List<Vehicle>();
        // will create a vehicle via consturctor of respectable vehicle

        public enum eVehicleType
        {
            GasMotorcycle = 1,
            ElectricMotorcycle = 2,
            GasCar = 3,
            ElectricCar = 4,
            Truck = 5
        }
    }
}
