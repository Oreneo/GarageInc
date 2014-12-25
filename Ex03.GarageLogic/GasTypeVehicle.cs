using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{ // enum or fields first ?
    public class GasTypeVehicle
    {
        private eGasType m_GasType;
        private float m_CurrentTankCapacityLiters;
        private float m_MaxTankCapacityLiters;

        public GasTypeVehicle(eGasType i_GasType, float i_CurrentTankCapacityLiters, float i_MaxTankCapacityLiters)
        {
            m_GasType = i_GasType;
            m_CurrentTankCapacityLiters = i_CurrentTankCapacityLiters;
            m_MaxTankCapacityLiters = i_MaxTankCapacityLiters;
        }

        public enum eGasType
        {
            Diesel,
            Octane95,
            Octane96,
            Octane98
        }

        public void refuel()   // will override method ???
        {

        }

        public eGasType GasType
        {
            get
            {
                return m_GasType;
            }
            set
            {
                m_GasType = value;
            }
        }

        public float CurrentTankCapacityLiters
        {
            get
            {
                return m_CurrentTankCapacityLiters;
            }
            set
            {
                m_CurrentTankCapacityLiters = value;
            }
        }

        public float MaxTankCapacityLiters
        {
            get
            {
                return m_MaxTankCapacityLiters;
            }
            set
            {
                m_MaxTankCapacityLiters = value;
            }
        }
    }
}
