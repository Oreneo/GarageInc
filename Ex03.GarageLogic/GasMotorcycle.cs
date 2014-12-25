using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public sealed class GasMotorcycle : Motorcycle
    {
        private GasTypeVehicle m_GasTypeVehicleUtil;  //deep copy in method , constructor
        private const float k_MotorcycleMaxTankCapacityLiters = 6.5f;
        private const GasTypeVehicle.eGasType k_MotorcycleGasType = GasTypeVehicle.eGasType.Octane96;

        public GasMotorcycle(float i_CurrentTankCapacityLiters, string i_ModelName, string i_PlateNumber,
            eLicenseType i_LicenseType, int i_EngineCapacityCc) :
            base(i_ModelName, i_PlateNumber, i_LicenseType, i_EngineCapacityCc, i_CurrentTankCapacityLiters, k_MotorcycleMaxTankCapacityLiters)
        {
            m_GasTypeVehicleUtil = new GasTypeVehicle(k_MotorcycleGasType, i_CurrentTankCapacityLiters, k_MotorcycleMaxTankCapacityLiters);
        }
    }
}
