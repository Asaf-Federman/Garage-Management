namespace Ex03.GarageLogic
{
    public class FueledCarEngine : FueledEngine
    {
        private const eFuelType k_FuelType = eFuelType.Octan96;
        private const float k_MaxFuelValueInLiters = 55;

        public FueledCarEngine(float i_CurrentFuelValue) : base(i_CurrentFuelValue, k_MaxFuelValueInLiters, k_FuelType)
        {
        }
    }
}
