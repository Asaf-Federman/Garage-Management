namespace Ex03.GarageLogic
{
    public class FueledTruckEngine : FueledEngine
    {
        private const eFuelType k_FuelType = eFuelType.Soler;
        private const float k_MaxFuelValueInLiters = 110;

        public FueledTruckEngine(float i_CurrentFuelValue) : base(i_CurrentFuelValue, k_MaxFuelValueInLiters, k_FuelType)
        {
        }
    }
}
