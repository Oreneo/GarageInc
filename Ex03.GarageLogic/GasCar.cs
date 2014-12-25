using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{ 
    public sealed class GasCar : Car
    {
        private GasTypeVehicle m_GasTypeVehicleUtil;  //deep copy in method , constructor
        private const float k_CarMaxTankCapacityLiters = 45;
        private const GasTypeVehicle.eGasType k_CarGasType = GasTypeVehicle.eGasType.Octane95;

        public GasCar(float i_CurrentTankCapacityLiters, string i_ModelName, string i_PlateNumber, 
            eCarColor i_CarColor, eNumOfDoors i_NumOfDoors) :
            base(i_ModelName, i_PlateNumber, i_CarColor, i_NumOfDoors, i_CurrentTankCapacityLiters, k_CarMaxTankCapacityLiters)
        {
            m_GasTypeVehicleUtil = new GasTypeVehicle(k_CarGasType, i_CurrentTankCapacityLiters, k_CarMaxTankCapacityLiters);
        }
    }
}
