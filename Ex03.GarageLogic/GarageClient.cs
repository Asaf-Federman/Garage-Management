using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageClient
    {
        public enum eVehicleState
        {
            InRepairStages,
            Repaired,
            Paid
        }

        private readonly Vehicle r_ClientVehicle;
        private readonly string r_VehicleOwnerName;
        private readonly string r_VehicleOwnerPhoneNumber;
        private eVehicleState m_VehicleState;

        public GarageClient(Vehicle i_VehicleToAdd, string i_VehicleOwnerName, string i_VehicleOwnerPhoneNumber)
        {
            m_VehicleState = eVehicleState.InRepairStages;
            r_ClientVehicle = i_VehicleToAdd;
            r_VehicleOwnerName = i_VehicleOwnerName;
            r_VehicleOwnerPhoneNumber = i_VehicleOwnerPhoneNumber;
        }

        public Dictionary<string, object> VehicleInformation()
        {
            Dictionary<string, object> vehicleInformationMap = new Dictionary<string, object>();
            vehicleInformationMap.Add("Owner name: ", OwnerName);
            vehicleInformationMap.Add("Owner phone number: ", OwnerPhoneNumber);
            vehicleInformationMap.Add("Vehicle's state: ", VehicleState);
            foreach (KeyValuePair<string, object> mapInformation in Vehicle.VehicleInformation())
            {
                vehicleInformationMap.Add(mapInformation.Key, mapInformation.Value);
            }

            return vehicleInformationMap;
        }

        public GarageClient(Vehicle i_VehicleToAdd)
        {
            m_VehicleState = eVehicleState.InRepairStages;
            r_ClientVehicle = i_VehicleToAdd;
            r_VehicleOwnerName = null;
            r_VehicleOwnerPhoneNumber = null;
        }

        public eVehicleState VehicleState
        {
            get
            {
                return m_VehicleState;
            }

            set
            {
                m_VehicleState = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return r_ClientVehicle;
            }
        }

        public string GetLicenseNumber()
        {
            return Vehicle.LicenseNumber;
        }

        public void InflateTiresToMaximumAirPressure()
        {
            Vehicle.InflateTiresToMaximumAirPressure();
        }

        public void RefuelVehicle(FueledEngine.eFuelType i_FuelType, float i_FuelToBeAdded)
        {
            FueledEngine vehicleToRefuel = r_ClientVehicle.VehicleEngine as FueledEngine;

            if (vehicleToRefuel != null)
            {
                vehicleToRefuel.RefuelVehicle(i_FuelType, i_FuelToBeAdded);
            }
            else
            {
                throw new System.ArgumentException("The type of the vehicle is incorrect.");
            }
        }

        public string OwnerName
        {
            get
            {
                return r_VehicleOwnerName;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return r_VehicleOwnerPhoneNumber;
            }
        }

        public void RechargeVehicle(int i_AmountOfMinutesToCharge)
        {
            ElectricEngine vehicleToRecharge = r_ClientVehicle.VehicleEngine as ElectricEngine;

            if (vehicleToRecharge != null)
            {
                vehicleToRecharge.RechargeBattery(i_AmountOfMinutesToCharge);
            }
            else
            {
                throw new System.ArgumentException("The type of the vehicle is incorrect.");
            }
        }
    }
}
