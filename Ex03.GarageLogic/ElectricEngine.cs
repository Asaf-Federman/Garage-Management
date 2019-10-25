using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class ElectricEngine : Engine
    {
        public ElectricEngine(float i_RemainingBatteryTime, float i_MaxBatteryTime) : base(i_RemainingBatteryTime, i_MaxBatteryTime)
        {
        }

        public override Dictionary<string, object> EngineInformation()
        {
            Dictionary<string, object> engineInfoMap = new Dictionary<string, object>();

            engineInfoMap.Add("Remaining battery energy in hours: ", RemainingEnergy);
            engineInfoMap.Add("Max battery energy capacity in hours: ", MaxEnergyCapacity);

            return engineInfoMap;
        }

        public void ChargeBattery(int i_AmountOfBatteryHoursToAdd)
        {
            RechargeBattery(i_AmountOfBatteryHoursToAdd * 60);
        }

        public void RechargeBattery(int i_AmountOfMinutesToRecharge)
        {
            float amountOfEnergyInHoursToRecharge;
            int maximumValue;

            amountOfEnergyInHoursToRecharge = (float)i_AmountOfMinutesToRecharge / 60f;
            if (RemainingEnergy + amountOfEnergyInHoursToRecharge > MaxEnergyCapacity)
            {
                maximumValue = (int)(MaxEnergyCapacity - RemainingEnergy) * 60;
                throw new Ex03.GarageLogic.ValueOutOfRangeException(0f, maximumValue);
            }
            else
            {
                RemainingEnergy = RemainingEnergy + amountOfEnergyInHoursToRecharge;
            }
        }
    }
}
