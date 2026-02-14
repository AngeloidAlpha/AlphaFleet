namespace AlphaFleet.Common
{
    public static class EntityValidation
    {
        /* Ships */
        public const int ShipNameMinLength = 3;
        public const int ShipNameMaxLength = 100;
        public const int ShipTypeMinLength = 3;
        public const int ShipTypeMaxLength = 50;
        public const int ShipDescriptionMinLength = 10;
        public const int ShipDescriptionMaxLength = 5000;
        public const int ShipProductionYearMinValue = 2200;
        public const int ShipProductionYearMaxValue = 5001;

        /* Fleets */
        public const int FleetNameMinLength = 3;
        public const int FleetNameMaxLength = 100;
        public const int FleetLocationNameMinLength = 3;
        public const int FleetLocationNameMaxLength = 100;
    }
}
