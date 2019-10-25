using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class FueledEngine : Engine
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private readonly eFuelType r_FuelType;

        public FueledEngine(float i_RemainingFuel, float i_MaxFuelValue, eFuelType i_FuelType) : base(i_RemainingFuel, i_MaxFuelValue)
        {
            r_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public override Dictionary<string, object> EngineInformation()
        {
            Dictionary<string, object> engineInfoMap = new Dictionary<string, object>();

            engineInfoMap.Add("Fuel type: ", FuelType);
            engineInfoMap.Add("Remaining fuel in liters: ", RemainingEnergy);
            engineInfoMap.Add("Max fuel capacity in liters: ", MaxEnergyCapacity);

            return engineInfoMap;
        }

        public void RefuelVehicle(eFuelType i_FuelType, float i_AmountOfFuelToAdd)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new System.ArgumentException("Fuel Type is incorrect");
            }
            else if (RemainingEnergy + i_AmountOfFuelToAdd > MaxEnergyCapacity)
            {
                throw new Ex03.GarageLogic.ValueOutOfRangeException(0f, MaxEnergyCapacity - RemainingEnergy);
            }
            else
            {
                RemainingEnergy = RemainingEnergy + i_AmountOfFuelToAdd;
            }
        }
    }
}
