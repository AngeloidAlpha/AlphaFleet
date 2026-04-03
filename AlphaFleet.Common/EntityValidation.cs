namespace AlphaFleet.Common
{
    public static class EntityValidation
    {
        /* Ships */
        public const int ShipNameMinLength = 3;
        public const int ShipNameMaxLength = 100;
        public const int ShipDescriptionMinLength = 10;
        public const int ShipDescriptionMaxLength = 5000;
        public const int ShipProductionYearMinValue = 2200;
        public const int ShipProductionYearMaxValue = 5001;

        /* Fleets */
        public const int FleetNameMinLength = 3;
        public const int FleetNameMaxLength = 100;
        public const int FleetLocationNameMinLength = 3;
        public const int FleetLocationNameMaxLength = 100;

        /* Admirals */
        public const int AdmiralNameMinLength = 2;
        public const int AdmiralNameMaxLength = 100;
        public const int AdmiralBioMaxLength = 3000;

        /* Stations */
        public const int StationNameMinLength = 2;
        public const int StationNameMaxLength = 100;
        public const int StationLocationMinLength = 3;
        public const int StationLocationMaxLength = 100;
        public const int StationDescriptionMinLength = 10;
        public const int StationDescriptionMaxLength = 5000;
        public const int StationHealthMinValue = 0;
        public const int StationHealthMaxValue = 10000;

        /* Battle */
        public const int BattleDamageMinValue = 0;
        public const int BattleDamageMaxValue = 2147483647;
        public const int BattleDescriptionMaxLength = 5000;
    }
}
