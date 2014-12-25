using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public sealed class ElectricMotorcycle : Motorcycle
    {
        private ElectricTypeVehicle m_ElectricTypeVehicleUtil;  //deep copy in method , constructor
        private const float k_MaxMotorcycleBatteryTimeMinutes = 108;

        public ElectricMotorcycle(float i_CurrentMotorcycleBatteryTimeRemainingMinutes, string i_ModelName, string i_PlateNumber,
            eLicenseType i_LicenseType, int i_EngineCapacityCc) :
            base(i_ModelName, i_PlateNumber, i_LicenseType, i_EngineCapacityCc, i_CurrentMotorcycleBatteryTimeRemainingMinutes,
            k_MaxMotorcycleBatteryTimeMinutes)
        {
            m_ElectricTypeVehicleUtil = new ElectricTypeVehicle(i_CurrentMotorcycleBatteryTimeRemainingMinutes, k_MaxMotorcycleBatteryTimeMinutes);
        }
    }
}
