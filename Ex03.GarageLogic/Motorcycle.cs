using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        protected eLicenseType m_LicenseType;
        protected int m_EngineCapacityCc;          // 50 - 2000
        private const int k_MotorcycleNumOfWheels = 2;
        private const float k_CarWheelAirPressure = 30;

        public Motorcycle(string i_ModelName, string i_PlateNumber, eLicenseType i_LicenseType,
            int i_EngineCapacityCc, float i_CurrentEnergyCapacity, float i_MaxEnergyCapacity)
            : base(i_ModelName, i_PlateNumber, i_CurrentEnergyCapacity, i_MaxEnergyCapacity)
        {
            m_NumOfWheels = k_MotorcycleNumOfWheels;
            m_WheelAirPressure = k_CarWheelAirPressure;
            m_LicenseType = i_LicenseType;
            m_EngineCapacityCc = i_EngineCapacityCc;
        }

        public enum eLicenseType
        {
            A = 1,
            A1 = 2,
            AB = 3,
            B2 = 4
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineCapacityCc
        {
            get
            {
                return m_EngineCapacityCc;
            }
            set
            {
                m_EngineCapacityCc = value;
            }
        }
    }
}
