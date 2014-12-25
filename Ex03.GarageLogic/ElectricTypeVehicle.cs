using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricTypeVehicle
    {
        private float m_CurrentBatteryTimeRemainingMinutes;
        private float m_MaxBatteryTimeMinutes;

        public ElectricTypeVehicle(float i_CurrentBatteryTimeRemainingMinutes, float i_MaxBatteryTimeMinutes)
        {
            m_CurrentBatteryTimeRemainingMinutes = i_CurrentBatteryTimeRemainingMinutes;
            m_MaxBatteryTimeMinutes = i_MaxBatteryTimeMinutes;
        }

        public void recharge()   // will override method ???
        {

        }

        public float CurrentBatteryTimeRemainingMinutes
        {
            get
            {
                return m_CurrentBatteryTimeRemainingMinutes;
            }
            set
            {
                m_CurrentBatteryTimeRemainingMinutes = value;
            }
        }

        public float MaxBatteryTimeMinutes
        {
            get
            {
                return m_MaxBatteryTimeMinutes;
            }
            set
            {
                m_MaxBatteryTimeMinutes = value;
            }
        }
    }
}
