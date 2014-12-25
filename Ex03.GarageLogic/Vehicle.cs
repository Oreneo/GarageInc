using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_PlateNumber;
        protected float m_PercentOfRemainingEnergy;
        protected List<int> m_Wheels;      // list of wheels object with properties and shit
        protected int m_NumOfWheels;
        protected float m_WheelAirPressure;

        public Vehicle(string i_ModelName, string i_PlateNumber, float i_CurrentEnergyCapacity, float i_MaxEnergyCapacity)
        {
            m_ModelName = i_ModelName;
            m_PlateNumber = i_PlateNumber;
            
            calcPercentOfRemainingEnergy(i_CurrentEnergyCapacity, i_MaxEnergyCapacity);
            ///create wheel class or something
        }

        public void calcPercentOfRemainingEnergy(float i_CurrentEnergyCapacity, float i_MaxEnergyCapacity)   //virtual ?
        {
            m_PercentOfRemainingEnergy = (i_CurrentEnergyCapacity / i_MaxEnergyCapacity) * 100;
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }

        public string PlateNumber
        {
            get
            {
                return m_PlateNumber;
            }
            set
            {
                m_PlateNumber = value;
            }
        }

        public float PercentOfRemainingEnergy
        {
            get
            {
                return m_PercentOfRemainingEnergy;
            }
            set
            {
                m_PercentOfRemainingEnergy = value;
            }
        }

        public int NumOfWheels
        {
            get
            {
                return m_NumOfWheels;
            }
            set
            {
                m_NumOfWheels = value;
            }
        }

        public float WheelAirPressure
        {
            get
            {
                return m_WheelAirPressure;
            }
            set
            {
                m_WheelAirPressure = value;
            }
        }
    }
}