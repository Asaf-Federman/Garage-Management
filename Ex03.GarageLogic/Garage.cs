using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly List<GarageClient> m_CollectionOfVehicles;

        public Garage()
        {
            m_CollectionOfVehicles = new List<GarageClient>();
        }

        public bool AddVehicle(Vehicle i_VehicleToAdd, string i_VehicleOwnerName, string i_VehicleOwnerPhoneNumber)
        {
            GarageClient vehicleToLookFor = SearchForVehicleInCollection(i_VehicleToAdd.LicenseNumber);
            bool v_isVehicleExistInGarageList = true;

            if (vehicleToLookFor == null)
            {
                m_CollectionOfVehicles.Add(new GarageClient(i_VehicleToAdd, i_VehicleOwnerName, i_VehicleOwnerPhoneNumber));
            }
            else
            {
                vehicleToLookFor.VehicleState = GarageClient.eVehicleState.InRepairStages;
                v_isVehicleExistInGarageList = !v_isVehicleExistInGarageList;
            }

            return v_isVehicleExistInGarageList;
        }

        public List<string> PrintListOfLicenseNumber(params GarageClient.eVehicleState[] i_VehicleState)
        {
            List<string> licenseNumberListToPrint = new List<string>();

            if (i_VehicleState.Length == 0)
            {
                foreach (GarageClient garageVechile in m_CollectionOfVehicles)
                {
                    licenseNumberListToPrint.Add(garageVechile.GetLicenseNumber());
                }
            }
            else
            {
                foreach (GarageClient garageVechile in m_CollectionOfVehicles)
                {
                    if (garageVechile.VehicleState == i_VehicleState[0])
                    {
                        licenseNumberListToPrint.Add(garageVechile.GetLicenseNumber());
                    }
                }
            }

            return licenseNumberListToPrint;
        }

        public void ChangeVehicleState(string i_LicenseNumber, GarageClient.eVehicleState i_NewVehicleState)
        {
            GarageClient vehicleToLookFor = SearchForVehicleInCollection(i_LicenseNumber);

            if (vehicleToLookFor != null)
            {
                vehicleToLookFor.VehicleState = i_NewVehicleState;
            }
            else
            {
                throw new System.ArgumentException("Vehicle isn't in the garage.");
            }
        }

        public void InflateTiresToMaximumAirPressure(string i_LicenseNumber)
        {
            GarageClient vehicleToLookFor = SearchForVehicleInCollection(i_LicenseNumber);

            if (vehicleToLookFor != null)
            {
                vehicleToLookFor.InflateTiresToMaximumAirPressure();
            }
            else
            {
                throw new System.ArgumentException("Vehicle isn't in the garage.");
            }
        }

        public void RefuelVehicle(string i_LicenseNumber, FueledEngine.eFuelType i_FuelType, float i_FuelToBeAdded)
        {
            GarageClient vehicleToLookFor = SearchForVehicleInCollection(i_LicenseNumber);

            if (vehicleToLookFor != null)
            {
                vehicleToLookFor.RefuelVehicle(i_FuelType, i_FuelToBeAdded);
                vehicleToLookFor.Vehicle.UpdatePowerPercentage();
            }
            else
            {
                throw new System.ArgumentException("Vehicle isn't in the garage.");
            }
        }

        public void RechargeVehicle(string i_LicenseNumber, int i_AmountOfMinutesToCharge)
        {
            GarageClient vehicleToLookFor = SearchForVehicleInCollection(i_LicenseNumber);

            if (vehicleToLookFor != null)
            {
                vehicleToLookFor.RechargeVehicle(i_AmountOfMinutesToCharge);
                vehicleToLookFor.Vehicle.UpdatePowerPercentage();
            }
            else
            {
                throw new System.ArgumentException("Vehicle isn't in the garage.");
            }
        }

        public Dictionary<string, object> GetVehicleInformation(string i_LicenseNumber)
        {
            GarageClient vehicleToLookFor;

            vehicleToLookFor = SearchForVehicleInCollection(i_LicenseNumber);
            if (vehicleToLookFor == null)
            {
                throw new System.ArgumentException("Vehicle isn't in the garage.");
            }

            return vehicleToLookFor.VehicleInformation();
        }

        public GarageClient SearchForVehicleInCollection(string i_LicenseNumber)
        {
            bool v_isVehicleExistInCollection = false;
            GarageClient vehicleToLookFor = null;

            foreach (GarageClient garageClient in m_CollectionOfVehicles)
            {
                if (garageClient.GetLicenseNumber() == i_LicenseNumber)
                {
                    v_isVehicleExistInCollection = !v_isVehicleExistInCollection;
                    vehicleToLookFor = garageClient;
                    break;
                }
            }

            return vehicleToLookFor;
        }
    }
}
