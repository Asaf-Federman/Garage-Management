using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motorbike : Vehicle
    {
        public enum eLicenseType
        {
            B,
            A2,
            A1,
            A
        }

        private const int k_AmountOfTires = 2;
        private const float k_MaximumAirPressure = 33;
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineCapacity;

        public Motorbike(eLicenseType i_LicenseType, int i_EngineCapacity, string i_LicenseNumber, string i_Model, float i_CurrentAirPressure, string i_ManufacturerName, Engine i_VehicleEngine) :
            base(i_LicenseNumber, i_Model, i_VehicleEngine)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
            this.TireCollection = CreateTires(i_CurrentAirPressure, i_ManufacturerName, k_MaximumAirPressure, k_AmountOfTires);
        }

        public override Dictionary<string, object> VehicleInformation()
        {
            Dictionary<string, object> vehicleInformationMap = new Dictionary<string, object>();
            vehicleInformationMap.Add("License type: ", LicenseType);
            vehicleInformationMap.Add("Engine capacity: ", EngineCapacity);
            vehicleInformationMap.Add("Amount of tires: ", k_AmountOfTires);
            foreach (KeyValuePair<string, object> mapInformation in base.VehicleInformation())
            {
                vehicleInformationMap.Add(mapInformation.Key, mapInformation.Value);
            }

            return vehicleInformationMap;
        }

        public int AmountOfTires
        {
            get
            {
                return k_AmountOfTires;
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return r_LicenseType;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return r_EngineCapacity;
            }
        }
    }
}
