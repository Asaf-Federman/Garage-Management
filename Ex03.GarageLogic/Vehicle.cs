using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_Model;
        private readonly string r_LicenseNumber;
        private List<Tire> r_TireCollection;
        private Engine m_VehicleEngine;
        private float m_PowerPercentage;

        public Vehicle(string i_LicenseNumber, string i_Model, Engine i_VehicleEngine)
        {
            r_Model = i_Model;
            r_LicenseNumber = i_LicenseNumber;
            m_VehicleEngine = i_VehicleEngine;
            UpdatePowerPercentage();
        }

        public void UpdatePowerPercentage()
        {
            PowerPercentage = VehicleEngine.CalculatePowerPercentage();
        }

        public virtual Dictionary<string, object> VehicleInformation()
        {
            Dictionary<string, object> vehicleInformationMap = new Dictionary<string, object>();

            vehicleInformationMap.Add("Vehicle model: ", Model);
            vehicleInformationMap.Add("License number: ", LicenseNumber);
            vehicleInformationMap.Add("Power Percentage of the engine: ", PowerPercentage);
            foreach (KeyValuePair<string, object> mapInformation in VehicleEngine.EngineInformation())
            {
                vehicleInformationMap.Add(mapInformation.Key, mapInformation.Value);
            }

            foreach (KeyValuePair<string, object> mapInformation in TireCollection[0].TireInformation())
            {
                vehicleInformationMap.Add(mapInformation.Key, mapInformation.Value);
            }

            return vehicleInformationMap;
        }

        public List<Tire> TireCollection
        {
            get
            {
                return r_TireCollection;
            }

            set
            {
                r_TireCollection = value;
            }
        }

        public Engine VehicleEngine
        {
            get
            {
                return m_VehicleEngine;
            }

            set
            {
                m_VehicleEngine = value;
            }
        }

        public string Model
        {
            get
            {
                return r_Model;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public float PowerPercentage
        {
            get
            {
                return m_PowerPercentage;
            }

            set
            {
                m_PowerPercentage = value;
            }
        }

        protected List<Tire> CreateTires(float i_CurrentAirPressure, string i_ManufacturerName, float i_MaximumAirPressure, int i_AmountOfTires)
        {
            List<Tire> tireCollection = new List<Tire>(i_AmountOfTires);

            for (int i = 0; i < i_AmountOfTires; ++i)
            {
                tireCollection.Add(new Tire(i_ManufacturerName, i_CurrentAirPressure, i_MaximumAirPressure));
            }

            return tireCollection;
        }

        public void InflateTiresToMaximumAirPressure()
        {
            foreach (Tire tireToInflate in TireCollection)
            {
                tireToInflate.InflateTireToMaximumAirPressure();
            }
        }
    }
}
