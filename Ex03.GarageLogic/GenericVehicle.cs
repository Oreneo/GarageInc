using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class GenericVehicle : Vehicle
    {
        private GasTypeVehicle m_GasTypeVehicleUtil;  //deep copy
        private bool m_ContainsDangerousSubstance;
        private float m_MaximumAllowedCarryingWeight;
        private float m_CurrentCarryingWeight;
        private const int k_TruckNumOfWheels = 8;
        private const float k_TruckWheelAirPressure = 24;
        private const float k_TruckMaxTankCapacityLiters = 200;
        private const GasTypeVehicle.eGasType k_TruckGasType = GasTypeVehicle.eGasType.Diesel;

        // base constructor is called first but derived initializers come before

        public GenericVehicle(bool i_ContainsDangerousSubstance, float i_MaximumAllowedCarryingWeight, float i_CurrentCarryingWeight, 
            float i_CurrentTankCapacityLiters, string i_ModelName, string i_PlateNumber) :
            base(i_ModelName, i_PlateNumber, i_CurrentTankCapacityLiters, k_TruckMaxTankCapacityLiters)
        {
            m_NumOfWheels = k_TruckNumOfWheels;
            m_WheelAirPressure = k_TruckWheelAirPressure;
            
            m_ContainsDangerousSubstance = i_ContainsDangerousSubstance;
            m_MaximumAllowedCarryingWeight = i_MaximumAllowedCarryingWeight;
            m_CurrentCarryingWeight = i_CurrentCarryingWeight;

            m_GasTypeVehicleUtil = new GasTypeVehicle(k_TruckGasType, i_CurrentTankCapacityLiters, k_TruckMaxTankCapacityLiters);
        }
    }
}
