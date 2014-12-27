using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private Vehicle m_TheVehicle;
        private string m_VehicleOwnerName;
        private string m_VehicleOwnerPhone;
        private eVehicleGarageStatus m_VehicleStatus = eVehicleGarageStatus.InRepair;

        public enum eVehicleGarageStatus
        {
            InRepair,
            Repaired,
            Payed
        }

        public VehicleInGarage(Vehicle i_Vehicle)
        {
            m_TheVehicle = i_Vehicle;
        }

        public Vehicle TheVehicle
        {
            get
            {
                return m_TheVehicle;
            }
            set
            {
                m_TheVehicle = value;
            }
        }

        public string VehicleOwnerName
        {
            get
            {
                return m_VehicleOwnerName;
            }
            set
            {
                m_VehicleOwnerName = value;
            }
        }

        public string VehicleOwnerPhone
        {
            get
            {
                return m_VehicleOwnerPhone;
            }
            set
            {
                m_VehicleOwnerPhone = value;
            }
        }

        public eVehicleGarageStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }
    }
}
