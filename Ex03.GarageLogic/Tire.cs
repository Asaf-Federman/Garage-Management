using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Tire
    {
        private const float k_MinimumAirPressure = 0;
        private readonly string r_ManufacturerName;
        private readonly float r_MaximumAirPressureByManufacturer;
        private float m_CurrentAirPressure;

        public Tire(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaximumAirPressureByManufacturer)
        {
            if (i_CurrentAirPressure > i_MaximumAirPressureByManufacturer || i_CurrentAirPressure < k_MinimumAirPressure)
            {
                ValueOutOfRangeException newException = new Ex03.GarageLogic.ValueOutOfRangeException(k_MinimumAirPressure, i_MaximumAirPressureByManufacturer);
                newException.Source = "Tire";
                throw newException;
            }

            r_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaximumAirPressureByManufacturer = i_MaximumAirPressureByManufacturer;
        }

        public void AirPressureInflate(float i_AirPressureToAdd)
        {
            if (i_AirPressureToAdd + CurrentAirPressure <= MaximumAirPressure)
            {
                m_CurrentAirPressure = m_CurrentAirPressure + i_AirPressureToAdd;
            }
            else
            {
                throw new Ex03.GarageLogic.ValueOutOfRangeException(0f, MaximumAirPressure - CurrentAirPressure);
            }
        }

        public Dictionary<string, object> TireInformation()
        {
            Dictionary<string, object> tireInformationMap = new Dictionary<string, object>();
            tireInformationMap.Add("Tire manufacturer name: ", ManufacturerName);
            tireInformationMap.Add("Current air pressure: ", CurrentAirPressure);
            tireInformationMap.Add("Maximum air pressure: ", MaximumAirPressure);

            return tireInformationMap;
        }

        public string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaximumAirPressure
        {
            get
            {
                return r_MaximumAirPressureByManufacturer;
            }
        }

        public void InflateTireToMaximumAirPressure()
        {
            CurrentAirPressure = MaximumAirPressure;
        }
    }
}
