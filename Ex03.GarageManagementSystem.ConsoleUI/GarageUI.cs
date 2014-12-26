using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    public class GarageUI
    {
        private int m_MainMenuUserChoice = 0;
        const int k_MinRange = 1;
        const int k_MaxMainMenuRange = 8;
        readonly int r_VehicleTypeEnumMaxRange = Enum.GetNames(typeof(Ex03.GarageLogic.VehicleGenerator.eVehicleType)).Length;

        public GarageUI()
        {
            StartGarage();
        }

        public void StartGarage()
        {
            mainMenuDisplay();
            mainMenuAction();

            Console.WriteLine("Press enter to exit\n");
            Console.ReadLine();
        }

        public void mainMenuDisplay()
        {
            string outputStr;
            
            outputStr = String.Format(@"Welcome to Oren & Tomer Garage Inc.

Please enter your choice :

1) Enter a vehicle to the garage
2) View plate numbers of currently stored cars in garage
3) Change status of vehicle in garage
4) Inflate wheels of stored vehicle to maximum
5) Refuel gas type vehicle
6) Recharge electric type vehicle
7) View full details of stored vehicle
8) exit" + Environment.NewLine);

            getUserGoodInputInRange(k_MinRange, k_MaxMainMenuRange, outputStr);
        }

        public void mainMenuAction()
        {
            switch(m_MainMenuUserChoice)
            {
                case 1:
                    enterVehicleToGarage();
                    break;
                case 2:
                    viewListOfCarsInGarage();
                    break;
                case 3:
                    changeVehicleStatus();
                    break;
                case 4:
                    inflateVehicleWheels();
                    break;
                case 5:
                    refuelGasTypeVehicle();
                    break;
                case 6:
                    rechargeElectricTypeVehicle();
                    break;
                case 7:
                    viewVehicleDetails();
                    break;
                case 8:
                    Console.WriteLine("Goodbye\n");
                    break;
            }
        }

        public void enterVehicleToGarage()
        {
            // create vehicle via VehicleGenerator
            int i;
            string line;
            StringBuilder outputStr = new StringBuilder();
            Array vehicleTypeValues = Enum.GetValues(typeof(Ex03.GarageLogic.VehicleGenerator.eVehicleType));

            outputStr.AppendLine("Please choose vehicle from the following options:\n");

            for (i = 0; i < vehicleTypeValues.Length; i++)
            {
                line = String.Format("{0}) {1}", i + 1, Enum.GetName(typeof(Ex03.GarageLogic.VehicleGenerator.eVehicleType), i + 1));
                outputStr.AppendLine(line);
            }

            getUserGoodInputInRange(k_MinRange, r_VehicleTypeEnumMaxRange, outputStr.ToString());
        }

        public void viewListOfCarsInGarage()
        {

        }

        public void changeVehicleStatus()
        {

        }

        public void inflateVehicleWheels()
        {

        }

        public void refuelGasTypeVehicle()
        {

        }

        public void rechargeElectricTypeVehicle()
        {

        }

        public void viewVehicleDetails()
        {

        }

        public int getUserGoodInputInRange(int i_MinRange, int i_MaxRange, string outputStr)
        {
            string strUserChoice;
            bool goodInput = false;

            do
            {
                Console.WriteLine(outputStr);

                strUserChoice = Console.ReadLine();
                goodInput = int.TryParse(strUserChoice, out m_MainMenuUserChoice);
                if (m_MainMenuUserChoice < i_MinRange || m_MainMenuUserChoice > i_MaxRange)
                {
                    goodInput = false;
                }

                if (goodInput == false)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input. Please enter a number between {0} - {1} :\n", i_MinRange, i_MaxRange);
                }
            }
            while (goodInput == false);

            Console.Clear();

            return m_MainMenuUserChoice;
        }
    }
}