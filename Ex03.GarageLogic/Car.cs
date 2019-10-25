using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eCarColor
        {
            Red,
            Blue,
            Black,
            Gray
        }

        public enum eAmountOfCarDoor
        {
            Two = 2,
            Three,
            Four,
            Five
        }

        private const float k_MaximumAirPressure = 31;
        private const int k_AmountOfTires = 4;
        private readonly eCarColor r_CarColor;
        private readonly eAmountOfCarDoor r_AmountOfDoors;

        public Car(eCarColor i_CarColor, eAmountOfCarDoor i_AmountOfDoors, float i_CurrentAirPressure, string i_ManufacturerName, string i_LicenseNumber, string i_Model, Engine i_VehicleEngine)
            : base(i_LicenseNumber, i_Model, i_VehicleEngine)
        {
            r_AmountOfDoors = i_AmountOfDoors;
            r_CarColor = i_CarColor;
            r_AmountOfDoors = i_AmountOfDoors;
            TireCollection = CreateTires(i_CurrentAirPressure, i_ManufacturerName, k_MaximumAirPressure, k_AmountOfTires);
        }

        public eCarColor CarColor
        {
            get
            {
                return r_CarColor;
            }
        }

        public eAmountOfCarDoor AmountOfCarDoors
        {
            get
            {
                return r_AmountOfDoors;
            }
        }

        public override Dictionary<string, object> VehicleInformation()
        {
            Dictionary<string, object> vehicleInformationMap = new Dictionary<string, object>();
            vehicleInformationMap.Add("Car color: ", CarColor);
            vehicleInformationMap.Add("Amount of doors: ", AmountOfCarDoors);
            vehicleInformationMap.Add("Amount of tires: ", k_AmountOfTires);
            foreach (KeyValuePair<string, object> mapInformation in base.VehicleInformation())
            {
                vehicleInformationMap.Add(mapInformation.Key, mapInformation.Value);
            }

            return vehicleInformationMap;
        }
    }
}
