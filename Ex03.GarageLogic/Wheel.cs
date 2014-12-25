using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_ManufacturerMaxAirPressure;

        public bool InflateWheel(float i_AmountOfAirToAdd)
        {
            bool isGreaterThanMax = false;

            if ((m_CurrentAirPressure + i_AmountOfAirToAdd) > m_ManufacturerMaxAirPressure)
            {
                isGreaterThanMax = true;
            }
            else
            {
                m_CurrentAirPressure += i_AmountOfAirToAdd;
            }

            return isGreaterThanMax;
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
            set
            {
                m_ManufacturerName = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float ManufacturerMaxAirPressure
        {
            get
            {
                return m_ManufacturerMaxAirPressure;
            }
            set
            {
                m_ManufacturerMaxAirPressure = value;
            }
        }
    }
}
