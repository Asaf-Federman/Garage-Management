using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        private readonly Garage r_MyGarage;

        public UI()
        {
            r_MyGarage = new Garage();
            optionsMenu();
        }

        private void optionsMenu()
        {
            string currentStringToPrint;
            int inputFromUser;

            do
            {
                Console.Clear();
                currentStringToPrint = string.Format("Welcome to Garage Manager, Please enter the appropriate number below which represents your choice: {0}", Environment.NewLine);
                currentStringToPrint += string.Format("1. Enter a new vehicle to the Garage. {0}", Environment.NewLine);
                currentStringToPrint += string.Format("2. View the list of vehicle license numbers in the garage. {0}", Environment.NewLine);
                currentStringToPrint += string.Format("3. Change state of vehicle in the garage. {0}", Environment.NewLine);
                currentStringToPrint += string.Format("4. Inflate tires air pressure to maximum. {0}", Environment.NewLine);
                currentStringToPrint += string.Format("5. Refuel vehicle. {0}", Environment.NewLine);
                currentStringToPrint += string.Format("6. Recharge vehicle. {0}", Environment.NewLine);
                currentStringToPrint += string.Format("7. View Full details of vehicle. {0}", Environment.NewLine);
                currentStringToPrint += string.Format("8. EXIT.");
                Console.WriteLine(currentStringToPrint);
                inputFromUser = ValidationMethods.GetValidIndexInputFromUser(8);
                handleUserInput(inputFromUser);
            }
            while (inputFromUser != 8);
        }

        private void pauseUntillKeyPressed()
        {
            Console.WriteLine();
            Console.WriteLine("Please press Enter to get back to the Garage Manager menu.");
            Console.ReadLine();
        }

        private void handleUserInput(int i_IndexOfChoice)
        {
            switch (i_IndexOfChoice)
            {
                case 1:
                    insertVehicleToGarage();
                    break;
                case 2:
                    printLicenseNumbersOfAllVehiclesInGarage();
                    break;
                case 3:
                    changeVehicleState();
                    break;
                case 4:
                    inflateVehicleTires();
                    break;
                case 5:
                    refuelVehicle();
                    break;
                case 6:
                    rechargeBattery();
                    break;
                case 7:
                    printVehicleInformation();
                    break;
                default:
                    break;
            }
        }

        private void printLicenseNumbersOfAllVehiclesInGarage()
        {
            string currentStringToPrint;
            int indexOfValue = 0;
            int indexOfChoice;
            GarageClient.eVehicleState vehicleStateToLookFor;
            List<string> listToPrint;

            currentStringToPrint = string.Format("Please enter the appropriate number below which represents your choice: {0}", Environment.NewLine);
            currentStringToPrint += string.Format("{0}. View all vehicles. {1}", ++indexOfValue, Environment.NewLine);
            foreach (GarageClient.eVehicleState vehicleState in Enum.GetValues(typeof(GarageClient.eVehicleState)))
            {
                currentStringToPrint += string.Format("{0}. {1}. {2}", ++indexOfValue, vehicleState.ToString(), Environment.NewLine);
            }

            Console.Write(currentStringToPrint);
            indexOfChoice = ValidationMethods.GetValidIndexInputFromUser(indexOfValue) - 1;
            if (indexOfChoice == 0)
            {
                listToPrint = r_MyGarage.PrintListOfLicenseNumber();
            }
            else
            {
                indexOfChoice--;
                vehicleStateToLookFor = (GarageClient.eVehicleState)indexOfChoice;
                listToPrint = r_MyGarage.PrintListOfLicenseNumber(vehicleStateToLookFor);
            }

            if (listToPrint.Count == 0)
            {
                Console.WriteLine("There are no vehicles in the garage that match your requirements.");
            }
            else
            {
                Console.WriteLine("Those are the vehicle's licenses that match your requirements: ");
                indexOfValue = 0;
                foreach (string licenseToPrint in listToPrint)
                {
                    Console.WriteLine("{0}. {1}.", ++indexOfValue, licenseToPrint);
                }
            }

            pauseUntillKeyPressed();
        }

        private void changeVehicleState()
        {
            int indexOfValue = 0;
            string licenseNumber;
            GarageClient.eVehicleState newVehichleState;
            int indexOfChoice;

            Console.WriteLine("Please enter the vehicle's license number: ");
            licenseNumber = Console.ReadLine();
            while (licenseNumber.Length == 0)
            {
                Console.WriteLine("Please enter a valid vehicle's license number: ");
                licenseNumber = Console.ReadLine();
            }

            Console.WriteLine("Please enter the appropriate number below which represents the new vehicle state: ");
            foreach (string vehicleState in Enum.GetNames(typeof(GarageClient.eVehicleState)))
            {
                Console.WriteLine("{0}. {1}.", ++indexOfValue, vehicleState);
            }

            indexOfChoice = ValidationMethods.GetValidIndexInputFromUser(indexOfValue) - 1;
            newVehichleState = (GarageClient.eVehicleState)indexOfChoice;
            try
            {
                r_MyGarage.ChangeVehicleState(licenseNumber, newVehichleState);
            }
            catch (System.ArgumentException arguementException)
            {
                Console.WriteLine("{0}", arguementException.Message);
            }

            pauseUntillKeyPressed();
        }

        private void inflateVehicleTires()
        {
            string licenseNumber;

            Console.WriteLine("Please enter the vehicle's license number: ");
            licenseNumber = Console.ReadLine();
            while (licenseNumber.Length == 0)
            {
                Console.WriteLine("Please enter a valid vehicle's license number: ");
                licenseNumber = Console.ReadLine();
            }

            try
            {
                r_MyGarage.InflateTiresToMaximumAirPressure(licenseNumber);
            }
            catch (System.ArgumentException arguementException)
            {
                Console.WriteLine("{0}", arguementException.Message);
            }

            pauseUntillKeyPressed();
        }

        private void refuelVehicle()
        {
            string licenseNumber;
            float amountOfFuelToRefuel;
            FueledEngine.eFuelType fuelType;

            try
            {
                getInputForRefuelVehicle(out licenseNumber, out fuelType, out amountOfFuelToRefuel);
            }
            catch (FormatException formatException)
            {
                Console.WriteLine("{0}", formatException.Message);
                pauseUntillKeyPressed();
                return;
            }

            try
            {
                r_MyGarage.RefuelVehicle(licenseNumber, fuelType, amountOfFuelToRefuel);
            }
            catch (ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine("The values you entered are incorrect, please enter values between {0} to {1}", valueOutOfRangeException.MinValue, valueOutOfRangeException.MaxValue);
            }
            catch (ArgumentException arguementException)
            {
                Console.WriteLine(arguementException.Message);
            }
            finally
            {
                pauseUntillKeyPressed();
            }
        }

        private void getInputForRefuelVehicle(out string o_LicenseNumber, out FueledEngine.eFuelType o_FuelType, out float o_AmountOfFuelToRefuel)
        {
            int indexOfChoice;
            int indexOfValue = 0;

            Console.WriteLine("Please enter the vehicle's license number: ");
            o_LicenseNumber = Console.ReadLine();
            while (o_LicenseNumber.Length == 0)
            {
                Console.WriteLine("Please enter a valid vehicle's license number: ");
                o_LicenseNumber = Console.ReadLine();
            }

            Console.WriteLine("Please enter the amount of fuel to refuel with: ");
            do
            {
                if (!float.TryParse(Console.ReadLine(), out o_AmountOfFuelToRefuel))
                {
                    throw new FormatException("You entered invalid string (not a legal number)");
                }

                if (o_AmountOfFuelToRefuel <= 0)
                {
                    Console.WriteLine("Please enter a valid amount of fuel to refuel with: ");
                }
            }
            while (o_AmountOfFuelToRefuel <= 0);
            foreach (string vehicleState in Enum.GetNames(typeof(FueledEngine.eFuelType)))
            {
                Console.WriteLine("{0}. {1}.", ++indexOfValue, vehicleState);
            }

            indexOfChoice = ValidationMethods.GetValidIndexInputFromUser(indexOfValue) - 1;
            o_FuelType = (FueledEngine.eFuelType)indexOfChoice;
        }

        private void rechargeBattery()
        {
            string licenseNumber = null;
            int amountOfEnergyToCharge = 0;
            bool v_IsSuccessfulInput = true;

            try
            {
                getInputForRechargeBattery(out licenseNumber, out amountOfEnergyToCharge);
            }
            catch (FormatException formatException)
            {
                Console.WriteLine("{0}", formatException.Message);
                v_IsSuccessfulInput = !v_IsSuccessfulInput;
            }

            try
            {
                if (v_IsSuccessfulInput)
                {
                    r_MyGarage.RechargeVehicle(licenseNumber, amountOfEnergyToCharge);
                }
            }
            catch (ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine("The values you entered are incorrect, the values should be between {0} to {1}", valueOutOfRangeException.MinValue, valueOutOfRangeException.MaxValue);
            }
            catch (ArgumentException arguementException)
            {
                Console.WriteLine(arguementException.Message);
            }
            finally
            {
                pauseUntillKeyPressed();
            }
        }

        private void getInputForRechargeBattery(out string o_LicenseNumber, out int o_AmountOfEnergyToCharge)
        {
            Console.WriteLine("Please enter the vehicle's license number: ");
            o_LicenseNumber = Console.ReadLine();
            while (o_LicenseNumber.Length == 0)
            {
                Console.WriteLine("Please enter a valid vehicle's license number: ");
                o_LicenseNumber = Console.ReadLine();
            }

            Console.WriteLine("Please enter the amount of minutes to recharge the vehicle: ");
            do
            {
                if (!int.TryParse(Console.ReadLine(), out o_AmountOfEnergyToCharge))
                {
                    throw new FormatException("You entered invalid string (not an integer)");
                }

                if (o_AmountOfEnergyToCharge <= 0)
                {
                    Console.WriteLine("Please enter a valid amount of time (in minutes) to recharge:");
                }
            }
            while (o_AmountOfEnergyToCharge <= 0);
        }

        private void printVehicleInformation()
        {
            string licenseNumber;
            Dictionary<string, object> vehicleInformationMap = null;

            Console.WriteLine("Please enter the vehicle's license number: ");
            licenseNumber = Console.ReadLine();
            while (licenseNumber.Length == 0)
            {
                Console.WriteLine("Please enter a valid vehicle's license number: ");
                licenseNumber = Console.ReadLine();
            }

            try
            {
                vehicleInformationMap = r_MyGarage.GetVehicleInformation(licenseNumber);
            }
            catch (ArgumentException arguementException)
            {
                Console.WriteLine("{0}", arguementException.Message);
            }

            if (vehicleInformationMap != null)
            {
                foreach (KeyValuePair<string, object> mapInformation in vehicleInformationMap)
                {
                    Console.WriteLine("{0}{1}", mapInformation.Key, mapInformation.Value.ToString());
                }
            }

            pauseUntillKeyPressed();
        }

        private void insertVehicleToGarage()
        {
            string licenseNumberInput;
            string ownerName;
            string ownerPhoneNumber;
            bool v_IsVehicleExistInGarage = true;

            Console.WriteLine("Please enter the License Number of your vehicle: ");
            licenseNumberInput = Console.ReadLine();
            while (licenseNumberInput.Length == 0)
            {
                Console.WriteLine("Please enter a valid vehicle's license number: ");
                licenseNumberInput = Console.ReadLine();
            }

            if (r_MyGarage.SearchForVehicleInCollection(licenseNumberInput) == null)
            {
                v_IsVehicleExistInGarage = !v_IsVehicleExistInGarage;
            }

            if (v_IsVehicleExistInGarage)
            {
                Console.WriteLine("Your vehicle (license Number: {0}) already exists in the system. Therefore, the vehicle goes into repair stages.", licenseNumberInput);
                r_MyGarage.ChangeVehicleState(licenseNumberInput, GarageClient.eVehicleState.InRepairStages);
            }
            else
            {
                Console.WriteLine("Please enter the vehicle's owner name: ");
                ownerName = ValidationMethods.ValidNameInput(2, 20, false);
                Console.WriteLine("Please enter the phone number of vehicle's owner: ");
                ownerPhoneNumber = ValidationMethods.ValidPhoneNumberInput();
                chooseVehicleMenu(licenseNumberInput, ownerName, ownerPhoneNumber);
            }

            pauseUntillKeyPressed();
        }

        private void chooseVehicleMenu(string i_LicenseNumber, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            string currentStringToPrint;
            int inputFromUser;

            Console.Clear();
            currentStringToPrint = string.Format("Welcome to vehicle creation section, Please enter the appropriate number below which represents your choice: {0}", Environment.NewLine);
            currentStringToPrint += string.Format("1. Car. {0}", Environment.NewLine);
            currentStringToPrint += string.Format("2. Motorbike. {0}", Environment.NewLine);
            currentStringToPrint += string.Format("3. Truck. {0}", Environment.NewLine);
            Console.Write(currentStringToPrint);
            inputFromUser = ValidationMethods.GetValidIndexInputFromUser(3);
            getVehicleInput(i_LicenseNumber, inputFromUser, i_OwnerName, i_OwnerPhoneNumber);
        }

        private void getVehicleInput(string i_LicenseNumber, int i_IndexOfChoice, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            switch (i_IndexOfChoice)
            {
                case 1:
                    getCarInput(i_LicenseNumber, i_OwnerName, i_OwnerPhoneNumber);
                    break;
                case 2:
                    getMotorbikeInput(i_LicenseNumber, i_OwnerName, i_OwnerPhoneNumber);
                    break;
                case 3:
                    getTruckInput(i_LicenseNumber, i_OwnerName, i_OwnerPhoneNumber);
                    break;
                default:
                    break;
            }
        }

        private void getCarInput(string i_LicenseNumber, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            float currentAirPressure, remainingFuel;
            string tiresManufacturer, carModel;
            VehicleCreation.eTypeOfAbstractEngine typeOfEngine;
            Car.eCarColor carColor;
            Car newCarToAddToGarage = null;
            Car.eAmountOfCarDoor amountOfCarDoors;

            getModelVehicleFromUser(out carModel);
            getTiresInputFromUser(out currentAirPressure, out tiresManufacturer);
            getCarInputFromUser(out carColor, out amountOfCarDoors);
            getEngineInputFromUser(out remainingFuel, out typeOfEngine);
            try
            {
                if (typeOfEngine == VehicleCreation.eTypeOfAbstractEngine.Fuel)
                {
                    newCarToAddToGarage = Ex03.GarageLogic.VehicleCreation.CreateNewFueledCar(carColor, amountOfCarDoors, i_LicenseNumber, remainingFuel, carModel, tiresManufacturer, currentAirPressure);
                }
                else
                {
                    newCarToAddToGarage = Ex03.GarageLogic.VehicleCreation.CreateNewElectricCar(carColor, amountOfCarDoors, i_LicenseNumber, remainingFuel, carModel, tiresManufacturer, currentAirPressure);
                }
            }
            catch (Ex03.GarageLogic.ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine("Incorrect values entered for the {0}, the values should be between {1} to {2}", valueOutOfRangeException.Source, valueOutOfRangeException.MinValue, valueOutOfRangeException.MaxValue);
            }
            catch (ArgumentException arguementException)
            {
                Console.WriteLine("{0}", arguementException.Message);
            }

            if (newCarToAddToGarage != null)
            {
                r_MyGarage.AddVehicle(newCarToAddToGarage, i_OwnerName, i_OwnerPhoneNumber);
            }
        }

        private void getTruckInput(string i_LicenseNumber, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            bool v_IsContainsHazardousSubstances;
            float currentAirPressure, remainingFuel;
            string tiresManufacturer, truckModel;
            int cargoVolume;
            Truck newTruckToAddToGarage = null;

            getModelVehicleFromUser(out truckModel);
            getTiresInputFromUser(out currentAirPressure, out tiresManufacturer);
            getTruckInputFromUser(out v_IsContainsHazardousSubstances, out cargoVolume);
            getRemainningEnergyFromUser(out remainingFuel, VehicleCreation.eTypeOfAbstractEngine.Fuel);
            try
            {
                newTruckToAddToGarage = Ex03.GarageLogic.VehicleCreation.CreateNewFueledTruck(v_IsContainsHazardousSubstances, cargoVolume, i_LicenseNumber, remainingFuel, truckModel, tiresManufacturer, currentAirPressure);
            }
            catch (Ex03.GarageLogic.ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine("Incorrect values entered for the {0}, the values should be between {1} to {2}", valueOutOfRangeException.Source, valueOutOfRangeException.MinValue, valueOutOfRangeException.MaxValue);
            }
            catch (ArgumentException arguementException)
            {
                Console.WriteLine("{0}", arguementException.Message);
            }

            if (newTruckToAddToGarage != null)
            {
                r_MyGarage.AddVehicle(newTruckToAddToGarage, i_OwnerName, i_OwnerPhoneNumber);
            }
        }

        private void getMotorbikeInput(string i_LicenseNumber, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            float currentAirPressure, remainingFuel;
            string tiresManufacturer, motorbikeModel;
            int engineCapacity;
            VehicleCreation.eTypeOfAbstractEngine typeOfEngine;
            Motorbike.eLicenseType licenseType;
            Motorbike newMotorbikeToAddToGarage = null;

            getModelVehicleFromUser(out motorbikeModel);
            getTiresInputFromUser(out currentAirPressure, out tiresManufacturer);
            getMotorbikeInputFromUser(out licenseType, out engineCapacity);
            getEngineInputFromUser(out remainingFuel, out typeOfEngine);
            try
            {
                if (typeOfEngine == VehicleCreation.eTypeOfAbstractEngine.Fuel)
                {
                    newMotorbikeToAddToGarage = Ex03.GarageLogic.VehicleCreation.CreateNewFueledMotorbike(licenseType, engineCapacity, i_LicenseNumber, remainingFuel, motorbikeModel, tiresManufacturer, currentAirPressure);
                }
                else
                {
                    newMotorbikeToAddToGarage = Ex03.GarageLogic.VehicleCreation.CreateNewElectricMotorbike(licenseType, engineCapacity, i_LicenseNumber, remainingFuel, motorbikeModel, tiresManufacturer, currentAirPressure);
                }
            }
            catch (Ex03.GarageLogic.ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine("Incorrect values entered for the {0}, the values should be between {1} to {2}", valueOutOfRangeException.Source, valueOutOfRangeException.MinValue, valueOutOfRangeException.MaxValue);
            }
            catch (ArgumentException arguementException)
            {
                Console.WriteLine("{0}", arguementException.Message);
            }

            if (newMotorbikeToAddToGarage != null)
            {
                r_MyGarage.AddVehicle(newMotorbikeToAddToGarage, i_OwnerName, i_OwnerPhoneNumber);
            }
        }

        private void getModelVehicleFromUser(out string o_VehicleModel)
        {
            Console.WriteLine("Please enter the model of the vehicle: ");
            o_VehicleModel = ValidationMethods.ValidNameInput(1, 30, true);
        }

        private void getTiresInputFromUser(out float o_CurrentAirPressure, out string o_TiresManufacturer)
        {
            bool v_IsValidInputFromUser = false;

            Console.WriteLine("Please enter the current air pressure of your tires: ");
            do
            {
                if (float.TryParse(Console.ReadLine(), out o_CurrentAirPressure) && o_CurrentAirPressure > 0)
                {
                    v_IsValidInputFromUser = !v_IsValidInputFromUser;
                }

                if (!v_IsValidInputFromUser)
                {
                    Console.WriteLine("Bad input. Please enter a valid number.");
                }
            }
            while (!v_IsValidInputFromUser);

            Console.WriteLine("Please enter the manufacturer of your tires: ");
            o_TiresManufacturer = ValidationMethods.ValidNameInput(2, 25, false);
        }

        private void getEngineInputFromUser(out float o_RemainingEnergy, out VehicleCreation.eTypeOfAbstractEngine o_TypeOfEngine)
        {
            Console.WriteLine("Please enter the appropriate number below which represents the type of your engine: ");
            Console.WriteLine("1. Fueled Engine.");
            Console.WriteLine("2. Electric Engine.");
            o_TypeOfEngine = (VehicleCreation.eTypeOfAbstractEngine)(ValidationMethods.GetValidIndexInputFromUser(2) - 1);
            getRemainningEnergyFromUser(out o_RemainingEnergy, (VehicleCreation.eTypeOfAbstractEngine)o_TypeOfEngine);
        }

        private void getRemainningEnergyFromUser(out float o_RemainingEnergy, VehicleCreation.eTypeOfAbstractEngine i_TypeOfEngine)
        {
            bool v_IsValidInputFromUser = false;

            if (i_TypeOfEngine == VehicleCreation.eTypeOfAbstractEngine.Fuel)
            {
                Console.WriteLine("Please enter the amount of remaining fuel in liters: ");
            }
            else if (i_TypeOfEngine == VehicleCreation.eTypeOfAbstractEngine.Electric)
            {
                Console.WriteLine("Please enter the amount of remaining battery energy in hours: ");
            }

            do
            {
                if (float.TryParse(Console.ReadLine(), out o_RemainingEnergy) && o_RemainingEnergy > 0)
                {
                    v_IsValidInputFromUser = !v_IsValidInputFromUser;
                }

                if (!v_IsValidInputFromUser)
                {
                    Console.WriteLine("Bad input. Please enter a valid number.");
                }
            }
            while (!v_IsValidInputFromUser);
        }

        private void getCarInputFromUser(out Car.eCarColor o_CarColor, out Car.eAmountOfCarDoor o_AmountOfCarDoors)
        {
            int indexOfValue = 0;
            int indexOfChoice;

            Console.WriteLine("Please enter the appropriate number below which represents the color of your car: ");
            foreach (Car.eCarColor carColor in Enum.GetValues(typeof(Car.eCarColor)))
            {
                Console.WriteLine("{0}. {1}", ++indexOfValue, carColor);
            }

            indexOfChoice = ValidationMethods.GetValidIndexInputFromUser(indexOfValue) - 1;
            o_CarColor = (Car.eCarColor)indexOfChoice;
            indexOfValue = 0;
            Console.WriteLine("Please enter the appropriate number below which represents the amount of doors in your car: ");
            foreach (Car.eAmountOfCarDoor carColor in Enum.GetValues(typeof(Car.eAmountOfCarDoor)))
            {
                Console.WriteLine("{0}. {1}", ++indexOfValue, carColor);
            }

            indexOfChoice = ValidationMethods.GetValidIndexInputFromUser(indexOfValue);
            o_AmountOfCarDoors = (Car.eAmountOfCarDoor)(indexOfChoice + 1);
        }

        private void getMotorbikeInputFromUser(out Motorbike.eLicenseType o_LicenseType, out int o_eEngineCapacity)
        {
            bool v_IsValidInputFromUser;
            int indexOfValue = 0;

            Console.WriteLine("Please enter the appropriate number  which represents the license type of your motorbike: ");
            foreach (Motorbike.eLicenseType licenseType in Enum.GetValues(typeof(Motorbike.eLicenseType)))
            {
                Console.WriteLine("{0}. {1}", ++indexOfValue, licenseType);
            }

            ValidationMethods.GetValidIndexInputFromUser(indexOfValue);
            o_LicenseType = (Motorbike.eLicenseType)(indexOfValue - 1);
            Console.WriteLine("Please enter the capcity of your engine (in cubic centimeters): ");
            do
            {
                v_IsValidInputFromUser = int.TryParse(Console.ReadLine(), out o_eEngineCapacity);
                if (v_IsValidInputFromUser && o_eEngineCapacity < 1)
                {
                    Console.WriteLine("Bad input. Please enter a natural number.");
                    v_IsValidInputFromUser = !v_IsValidInputFromUser;
                }
            }
            while (!v_IsValidInputFromUser);
        }

        private void getTruckInputFromUser(out bool o_IsContainsHazardousSubstances, out int o_CargoVolume)
        {
            bool v_IsValidInputFromUser;
            int indexOfChoice;

            o_IsContainsHazardousSubstances = true;
            Console.WriteLine("Is your truck containing hazardous substances? (Choose the option number): ");
            Console.WriteLine("1. Yes. {0}2. No. ", Environment.NewLine);
            indexOfChoice = ValidationMethods.GetValidIndexInputFromUser(2);
            if (indexOfChoice == 2)
            {
                o_IsContainsHazardousSubstances = !o_IsContainsHazardousSubstances;
            }

            Console.WriteLine("Please enter the cargo volume (in kg): ");
            do
            {
                v_IsValidInputFromUser = int.TryParse(Console.ReadLine(), out o_CargoVolume);
                if (v_IsValidInputFromUser && o_CargoVolume < 1)
                {
                    Console.WriteLine("Bad input. Please enter a natural number.");
                    v_IsValidInputFromUser = !v_IsValidInputFromUser;
                }
            }
            while (!v_IsValidInputFromUser);
        }
    }
}
