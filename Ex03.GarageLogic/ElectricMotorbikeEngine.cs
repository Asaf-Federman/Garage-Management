namespace Ex03.GarageLogic
{
    public class ElectricMotorbikeEngine : ElectricEngine
    {
        private const float k_MaximumBatteryTime = 1.4f;

        public ElectricMotorbikeEngine(float i_RemainingBatteryTime) : base(i_RemainingBatteryTime, k_MaximumBatteryTime)
        {
        }
    }
}
