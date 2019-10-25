using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const float k_MaximumAirPressure = 26;
        private const int k_AmountOfTires = 12;
        private bool m_IsContainsHazardousSubstances;
        private float m_CargoVolume;

        public Truck(bool i_IsContainsHazardousSubstances, float i_CargoVolume, float i_CurrentAirPressure, string i_ManufacturerName, string i_LicenseNumber, string i_Model, Engine i_VehicleEngine) :
               base(i_LicenseNumber, i_Model, i_VehicleEngine)
        {
            m_IsContainsHazardousSubstances = i_IsContainsHazardousSubstances;
            m_CargoVolume = i_CargoVolume;
            this.TireCollection = CreateTires(i_CurrentAirPressure, i_ManufacturerName, k_MaximumAirPressure, k_AmountOfTires);
        }

        public override Dictionary<string, object> VehicleInformation()
        {
            Dictionary<string, object> vehicleInformationMap = new Dictionary<string, object>();

            vehicleInformationMap.Add("Is containing hazardous subtances: ", IsContainsHazardousSubstances);
            vehicleInformationMap.Add("Cargo Volume: ", CargoVolume);
            vehicleInformationMap.Add("Amount of tires: ", k_AmountOfTires);
            foreach (KeyValuePair<string, object> mapInformation in base.VehicleInformation())
            {
                vehicleInformationMap.Add(mapInformation.Key, mapInformation.Value);
            }

            return vehicleInformationMap;
        }

        public bool IsContainsHazardousSubstances
        {
            get
            {
                return m_IsContainsHazardousSubstances;
            }

            set
            {
                m_IsContainsHazardousSubstances = value;
            }
        }

        public float MaximumAirPressure
        {
            get
            {
                return k_MaximumAirPressure;
            }
        }

        public int AmountOfTires
        {
            get
            {
                return k_AmountOfTires;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }

            set
            {
                m_CargoVolume = value;
            }
        }
    }
}
