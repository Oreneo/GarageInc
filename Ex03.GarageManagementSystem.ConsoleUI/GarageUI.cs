using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    public class GarageUI
    {
        private int m_MainMenuUserChoice;
        const int k_MinRange = 1;
        const int k_MaxMainMenuRange = 8;
        const int k_MinMotorcycleEngineCapacityCc = 50;
        const int k_MaxMotorcycleEngineCapacityCc = 2000;
        readonly int r_VehicleTypeEnumMaxRange = Enum.GetNames(typeof(Ex03.GarageLogic.VehicleGenerator.eVehicleType)).Length;
        private GarageLogic.Garage m_TheGarage = new GarageLogic.Garage();

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

            m_MainMenuUserChoice = getUserGoodInputInRange(k_MinRange, k_MaxMainMenuRange, outputStr);
        }

        public void mainMenuAction()
        {
            int userChoice;
            string userInputPlateNumber;

            switch(m_MainMenuUserChoice)
            {
                case 1:
                    userInputPlateNumber = getPlateNumberFromUser();

                    if (!m_TheGarage.isInGarage(userInputPlateNumber))
                    {
                        userChoice = enterVehicleToGarageMenuDisplay();
                        enterVehicleToGarageAction(userChoice, userInputPlateNumber);
                    }
                    else
                    {
                        Console.WriteLine("{0} is already in the Garage.\n", userInputPlateNumber);
                    }
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

        public string getPlateNumberFromUser()
        {
            string vehiclePlateNumber;
            bool goodPlateNumber = true;

            Console.WriteLine("Enter vehicle plate number :\n");

            do
            {
                goodPlateNumber = true;
                vehiclePlateNumber = Console.ReadLine();

                if(!isStringAllLettersOrDigits(vehiclePlateNumber) || vehiclePlateNumber == String.Empty)
                {
                    goodPlateNumber = false;
                }

                if(goodPlateNumber == false)   // add these 2 lines to previous if clause ?
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input. Please enter plate number that consists of digits and/or letters :\n");
                }
            } 
            while(goodPlateNumber == false);

            return vehiclePlateNumber;
        }

        public int enterVehicleToGarageMenuDisplay()
        {
            int i;
            int userChoice;
            string line;
            StringBuilder outputStr = new StringBuilder();
            Array vehicleTypes = Enum.GetValues(typeof(Ex03.GarageLogic.VehicleGenerator.eVehicleType));

            outputStr.AppendLine("\nPlease choose vehicle from the following options:\n");

            for(i = 0; i < vehicleTypes.Length; i++)
            {
                line = String.Format("{0}) {1}", i + 1, Enum.GetName(typeof(Ex03.GarageLogic.VehicleGenerator.eVehicleType), i + 1));
                outputStr.AppendLine(line);
            }

            userChoice = getUserGoodInputInRange(k_MinRange, r_VehicleTypeEnumMaxRange, outputStr.ToString());
            
            return userChoice;
        }

        public void enterVehicleToGarageAction(int i_UserChoice, string i_VehiclePlateNumber)
        {
            Ex03.GarageLogic.VehicleGenerator.eVehicleType userChoiceEnum = (Ex03.GarageLogic.VehicleGenerator.eVehicleType)i_UserChoice;
            // data to collect from all hierarchy in order to create a car to enter to garage.
            // take into account some default values in the hierarchy.
            // GasCar, GasMotorcycle, ElectricCar, ElectricMotorcycle no need to gather info
            // From Vehicle :
            string vehiclePlateNumber = i_VehiclePlateNumber;
            string vehicleModelName;
            List<Ex03.GarageLogic.Wheel> vehicleWheels;
            // From GasTypeVehicle / ElectricTypeVehicle :
            float vehicleCurrentEnergyCapacity;
            // From Motorcycle :
            Ex03.GarageLogic.Motorcycle.eLicenseType motorcycleLicenseType;
            int motorcycleEngineCapacityCc;
            // From Car :
            Ex03.GarageLogic.Car.eCarColor carColor;
            Ex03.GarageLogic.Car.eNumOfDoors carNumOfDoors;
            // From Truck :
            bool truckContainsDangerousSubstance;
            float truckMaximumAllowedCarryingWeight;
            float truckCurrentCarryingWeight;
            // From Wheels. air pressure and manufacturer once.
            string wheelManufacturerName;
            float wheelCurrentAirPressure;
            float wheelManufacturerMaxAirPressure;

            getVehicleModelNameFromUser(out vehicleModelName);
            // getVehicleInfoFromUser(out vehicleModelName, out vehicleWheels, out vehicleCurrentEnergyCapacity);  //here 2 of these will only be determined at the end
            // continue here
            // continue here
            // continue here

            switch (userChoiceEnum)
            {
                case Ex03.GarageLogic.VehicleGenerator.eVehicleType.GasMotorcycle:
                    getMotorcycleInfoFromUser(out motorcycleEngineCapacityCc, out motorcycleLicenseType);
                    getGasTypeVehicleInfoFromUser();  // i am here
                    break;
                case Ex03.GarageLogic.VehicleGenerator.eVehicleType.ElectricMotorcycle:
                    getMotorcycleInfoFromUser(out motorcycleEngineCapacityCc, out motorcycleLicenseType);
                    getElectricTypeVehicleInfoFromUser();
                    break;
                case Ex03.GarageLogic.VehicleGenerator.eVehicleType.GasCar:
                    getCarInfoFromUser();
                    getGasTypeVehicleInfoFromUser();
                    break;
                case Ex03.GarageLogic.VehicleGenerator.eVehicleType.ElectricCar:
                    getCarInfoFromUser();
                    getElectricTypeVehicleInfoFromUser();
                    break;
                case Ex03.GarageLogic.VehicleGenerator.eVehicleType.Truck:
                    getTruckInfoFromUser();
                    getGasTypeVehicleInfoFromUser();
                    break;
            }
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
            int userChoice;
            string strUserChoice;
            bool goodInput = false;

            do
            {
                Console.WriteLine(outputStr);

                strUserChoice = Console.ReadLine();
                goodInput = int.TryParse(strUserChoice, out userChoice);
                if (userChoice < i_MinRange || userChoice > i_MaxRange)
                {
                    goodInput = false;
                    //throw new GarageLogic.ValueOutOfRangeException("Bad number input", i_MinRange, i_MaxRange);
                }

                if (goodInput == false)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input. Please enter a number between {0} - {1} :\n", i_MinRange, i_MaxRange);
                }
            }
            while (goodInput == false);

            Console.Clear();

            return userChoice;
        }

        public void getVehicleModelNameFromUser(out string io_VehicleModelName)
        {
            bool goodModelName = true;

            Console.WriteLine("Enter vehicle model name :");

            do
            {
                io_VehicleModelName = Console.ReadLine();
                if(!isStringAllLetters(io_VehicleModelName) || io_VehicleModelName == String.Empty)
                {
                    goodModelName = false;
                }

                if(goodModelName == false)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input. please enter model name in letters only :");
                }
            }
            while(goodModelName == false);
        }

        //public void getVehicleCurrentEnergyCapacityFromUser(out float io_VehicleCurrentEnergyCapacity)
        //{
        //    io_VehicleCurrentEnergyCapacity = 2;
        //}

        //public void getWheelsInfoFromUser(out List<Ex03.GarageLogic.Wheel> io_VehicleWheels)
        //{
        //    io_VehicleWheels = new List<Ex03.GarageLogic.Wheel>();
        //}

        public void getCarInfoFromUser()
        {

        }

        public void getMotorcycleInfoFromUser(out int io_MotorcycleEngineCapacityCc, out Ex03.GarageLogic.Motorcycle.eLicenseType io_MotorcycleLicenseType)
        {
            getMotorcycleEngineCapacityCcFromUser(out io_MotorcycleEngineCapacityCc);
            getMotorcycleLicenseTypeFromUser(out io_MotorcycleLicenseType);            
        }

        public void getMotorcycleEngineCapacityCcFromUser(out int io_MotorcycleEngineCapacityCc)
        {
            string outputStr = "\nEnter motorcycle engine capacity in CCs [50 - 2000] :\n";

            io_MotorcycleEngineCapacityCc = getUserGoodInputInRange(k_MinMotorcycleEngineCapacityCc, k_MaxMotorcycleEngineCapacityCc, outputStr);
        }

        public void getMotorcycleLicenseTypeFromUser(out Ex03.GarageLogic.Motorcycle.eLicenseType io_MotorcycleLicenseType)
        {
            int i;
            int userChoice;
            string line;
            StringBuilder outputStr = new StringBuilder();
            Array licenseTypes = Enum.GetValues(typeof(Ex03.GarageLogic.Motorcycle.eLicenseType));    // change to arraylist ?

            outputStr.AppendLine("Please choose license type from the following options:\n");

            for(i = 0; i < licenseTypes.Length; i++)
            {
                line = String.Format("{0}) {1}", i + 1, Enum.GetName(typeof(Ex03.GarageLogic.Motorcycle.eLicenseType), i + 1));
                outputStr.AppendLine(line);
            }

            userChoice = getUserGoodInputInRange(k_MinRange, Enum.GetNames(typeof(Ex03.GarageLogic.Motorcycle.eLicenseType)).Length, outputStr.ToString());
            io_MotorcycleLicenseType = (Ex03.GarageLogic.Motorcycle.eLicenseType)userChoice;
        }

        public void getGasTypeVehicleInfoFromUser()
        {

        }

        public void getElectricTypeVehicleInfoFromUser()
        {

        }

        public void getTruckInfoFromUser()
        {

        }

        public static bool isStringAllLetters(string str)
        {
            bool allLetters = true;

            foreach(char c in str)
            {
                if(!Char.IsLetter(c))
                {
                    allLetters = false;
                    break;
                }
            }

            return allLetters;
        }

        public static bool isStringAllLettersOrDigits(string str)
        {
            bool allLettersOrDigits = true;

            foreach(char c in str)
            {
                if(!Char.IsLetterOrDigit(c))
                {
                    allLettersOrDigits = false;
                    break;
                }
            }

            return allLettersOrDigits;
        }
    }
}