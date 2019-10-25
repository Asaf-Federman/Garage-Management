namespace Ex03.GarageLogic
{
    public class ElectricCarEngine : ElectricEngine
    {
        private const float k_MaximumBatteryTime = 1.8f;

        public ElectricCarEngine(float i_RemainingEngineTime) : base(i_RemainingEngineTime, k_MaximumBatteryTime)
        {
        }
    }
}
