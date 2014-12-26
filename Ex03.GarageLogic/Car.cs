using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected eCarColor m_CarColor;
        protected readonly eNumOfDoors r_NumOfDoors;
        private const int k_CarNumOfWheels = 4;
        private const float k_CarWheelAirPressure = 29;

        public Car(string i_ModelName, string i_PlateNumber, eCarColor i_CarColor, eNumOfDoors i_NumOfDoors,
            float i_CurrentEnergyCapacity, float i_MaxEnergyCapacity)
            : base(i_ModelName, i_PlateNumber, i_CurrentEnergyCapacity, i_MaxEnergyCapacity)
        {
            m_NumOfWheels = k_CarNumOfWheels;
            m_WheelAirPressure = k_CarWheelAirPressure;

            m_CarColor = i_CarColor;
            r_NumOfDoors = i_NumOfDoors;

            m_Wheels = new List<Wheel>(m_NumOfWheels);  // check in runtime if m_Wheels has been recieved from the son
        }

        public enum eCarColor
        {
            White,
            Green,
            Blue,
            Red
        }

        public enum eNumOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }
            set
            {
                m_CarColor = value;
            }
        }

        public eNumOfDoors NumOfDoors
        {
            get
            {
                return r_NumOfDoors;
            }
        }
    }
}
