using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public static class VehicleCreation
    {
        public enum eTypeOfAbstractEngine
        {
            Fuel,
            Electric
        }

        public static Car CreateNewElectricCar(Car.eCarColor i_CarColor, Car.eAmountOfCarDoor i_AmountOfDoors, string i_LicenseNumber, float i_RemainingBatteryTime, string i_Model, string i_ManufacturerName, float i_CurrentAirPressureForTheTires)
        {
            ElectricCarEngine newElectricCarEngine = new ElectricCarEngine(i_RemainingBatteryTime);
            Car newElectricCar = new Car(i_CarColor, i_AmountOfDoors, i_CurrentAirPressureForTheTires, i_ManufacturerName, i_LicenseNumber, i_Model, newElectricCarEngine);

            return newElectricCar;
        }

        public static Car CreateNewFueledCar(Car.eCarColor i_CarColor, Car.eAmountOfCarDoor i_AmountOfDoors, string i_LicenseNumber, float i_CurrentFuelByLiters, string i_Model, string i_ManufacturerName, float i_CurrentAirPressureForTheTires)
        {
            FueledCarEngine newFueledCarEngine = new FueledCarEngine(i_CurrentFuelByLiters);
            Car newFueledCar = new Car(i_CarColor, i_AmountOfDoors, i_CurrentAirPressureForTheTires, i_ManufacturerName, i_LicenseNumber, i_Model, newFueledCarEngine);

            return newFueledCar;
        }

        public static Motorbike CreateNewElectricMotorbike(Motorbike.eLicenseType i_LicenseType, int i_EngineCapacity, string i_LicenseNumber, float i_RemainingBatteryTime, string i_Model, string i_ManufacturerName, float i_CurrentAirPressureForTheTires)
        {
            ElectricMotorbikeEngine newElectricMotorbikeEngine = new ElectricMotorbikeEngine(i_RemainingBatteryTime);
            Motorbike newElectricMotorbike = new Motorbike(i_LicenseType, i_EngineCapacity, i_LicenseNumber, i_Model, i_CurrentAirPressureForTheTires, i_ManufacturerName, newElectricMotorbikeEngine);

            return newElectricMotorbike;
        }

        public static Motorbike CreateNewFueledMotorbike(Motorbike.eLicenseType i_LicenseType, int i_EngineCapacity, string i_LicenseNumber, float i_CurrentFuelByLiters, string i_Model, string i_ManufacturerName, float i_CurrentAirPressureForTheTires)
        {
            FueledMotorbikeEngine newFueledMotorbikeEngine = new FueledMotorbikeEngine(i_CurrentFuelByLiters);
            Motorbike newFueledMotorbike = new Motorbike(i_LicenseType, i_EngineCapacity, i_LicenseNumber, i_Model, i_CurrentAirPressureForTheTires, i_ManufacturerName, newFueledMotorbikeEngine);

            return newFueledMotorbike;
        }

        public static Truck CreateNewFueledTruck(bool i_IsContainsHazardousSubstances, float i_CargoVolume, string i_LicenseNumber, float i_CurrentFuelByLiters, string i_Model, string i_ManufacturerNames, float i_CurrentAirPressureForTheTires)
        {
            FueledTruckEngine newFueledTruckEngine = new FueledTruckEngine(i_CurrentFuelByLiters);
            Truck newFueledTruck = new Truck(i_IsContainsHazardousSubstances, i_CargoVolume, i_CurrentAirPressureForTheTires, i_ManufacturerNames, i_LicenseNumber, i_Model, newFueledTruckEngine);

            return newFueledTruck;
        }
    }
}
