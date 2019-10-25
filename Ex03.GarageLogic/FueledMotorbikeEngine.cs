namespace Ex03.GarageLogic
{
    public class FueledMotorbikeEngine : FueledEngine
    {
        private const eFuelType k_FuelType = eFuelType.Octan95;
        private const float k_MaxFuelValueInLiters = 8;

        public FueledMotorbikeEngine(float i_CurrentFuelValue) : base(i_CurrentFuelValue, k_MaxFuelValueInLiters, k_FuelType)
        {
        }
    }
}
