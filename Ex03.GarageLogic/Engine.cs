using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private const float k_MinimumEnergyCapacity = 0;
        private readonly float m_MaxEnergyCapacity;
        private float m_RemainingEnergy;

        public Engine(float i_RemainingEnergy, float i_MaxEnergyCapacity)
        {
            if (i_RemainingEnergy > i_MaxEnergyCapacity || i_RemainingEnergy < k_MinimumEnergyCapacity)
            {
                ValueOutOfRangeException newException = new ValueOutOfRangeException(k_MinimumEnergyCapacity, i_MaxEnergyCapacity);
                newException.Source = "Engine";
                throw newException;
            }

            m_MaxEnergyCapacity = i_MaxEnergyCapacity;
            m_RemainingEnergy = i_RemainingEnergy;
        }

        public virtual Dictionary<string, object> EngineInformation()
        {
            Dictionary<string, object> engineInfoMap = new Dictionary<string, object>();

            engineInfoMap.Add("Remaining energy: ", RemainingEnergy);
            engineInfoMap.Add("Max energy capacity: ", MaxEnergyCapacity);

            return engineInfoMap;
        }

        public float CalculatePowerPercentage()
        {
            float powerPercentage = (RemainingEnergy / MaxEnergyCapacity) * 100;
            return (float)Math.Round(powerPercentage, 2);
        }

        public float RemainingEnergy
        {
            get
            {
                return m_RemainingEnergy;
            }

            set
            {
                m_RemainingEnergy = value;
            }
        }

        public float MaxEnergyCapacity
        {
            get
            {
                return m_MaxEnergyCapacity;
            }
        }
    }
}
