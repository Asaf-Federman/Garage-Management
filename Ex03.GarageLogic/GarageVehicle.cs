namespace Ex03.GarageLogic
{
    public enum eVehicleState
    {
        InRepairStages,
        Repaired,
        Paid
    }

    public class GarageVehicle
    {
        private readonly Vehicle r_GarageVehicle;
        private readonly string r_VehicleOwnerName;
        private readonly string r_VehicleOwnerPhoneNumber;
        private eVehicleState m_VehicleState;

        public GarageVehicle(Vehicle i_VehicleToAdd, string i_VehicleOwnerName, string i_VehicleOwnerPhoneNumber)
        {
            m_VehicleState = eVehicleState.InRepairStages;
            r_GarageVehicle = i_VehicleToAdd;
            r_VehicleOwnerName = i_VehicleOwnerName;
            r_VehicleOwnerPhoneNumber = i_VehicleOwnerPhoneNumber;
        }

        public GarageVehicle(Vehicle i_VehicleToAdd)
        {
            m_VehicleState = eVehicleState.InRepairStages;
            r_GarageVehicle = i_VehicleToAdd;
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

        public string GetLicenseNumber()
        {
            return r_GarageVehicle.GetLicenseNumber;
        }

        public void InflateTiresToMaximumAirPressure()
        {
            r_GarageVehicle.InflateTiresToMaximumAirPressure();
        }

        public void RefuelVehicle(eFuelType i_FuelType, float i_FuelToBeAdded)
        {
            FuelPoweredVehicle vehicleToRefuel = r_GarageVehicle as FuelPoweredVehicle;

            if (vehicleToRefuel != null)
            {
                vehicleToRefuel.RefuelVehicle(i_FuelType, i_FuelToBeAdded);
            }
            else
            {
                throw new System.FormatException("The type of the vehicle is incorrect");
            }
        }

        public void RechargeVehicle(int i_AmountOfMinutesToCharge)
        {
            ElectricVehicle vehicleToRecharge = r_GarageVehicle as ElectricVehicle;

            if (vehicleToRecharge != null)
            {
                vehicleToRecharge.RechargeVehicle(i_AmountOfMinutesToCharge);
            }
            else
            {
                throw new System.FormatException("The type of the vehicle is incorrect");
            }
        }
    }
}
