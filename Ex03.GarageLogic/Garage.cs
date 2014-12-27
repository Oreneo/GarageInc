using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        List<VehicleInGarage> VehiclesInGarage = new List<VehicleInGarage>();

        public bool isInGarage(string i_UserInputPlateNumber)
        {
            bool foundPlateNumber = false;
            
            foreach (VehicleInGarage vehicle in VehiclesInGarage)
            {
                if(vehicle.TheVehicle.PlateNumber.Equals(i_UserInputPlateNumber))
                {
                    foundPlateNumber = true;
                    break;
                }
            }

            return foundPlateNumber;
        }
    }
}
