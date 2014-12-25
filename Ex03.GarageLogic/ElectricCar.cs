using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public sealed class ElectricCar : Car
    {
        private ElectricTypeVehicle m_ElectricTypeVehicleUtil;  //deep copy in method , constructor
        private const float k_MaxCarBatteryTimeMinutes = 156;

        public ElectricCar(float i_CurrentCarBatteryTimeRemainingMinutes, string i_ModelName, string i_PlateNumber, 
            eCarColor i_CarColor, eNumOfDoors i_NumOfDoors) :
            base(i_ModelName, i_PlateNumber, i_CarColor, i_NumOfDoors, i_CurrentCarBatteryTimeRemainingMinutes, k_MaxCarBatteryTimeMinutes)
        {
            m_ElectricTypeVehicleUtil = new ElectricTypeVehicle(i_CurrentCarBatteryTimeRemainingMinutes, k_MaxCarBatteryTimeMinutes);
        }
    }
}
