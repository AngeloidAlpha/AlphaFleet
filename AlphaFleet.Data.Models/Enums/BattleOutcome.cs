using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaFleet.Data.Models.Enums
{
    public enum BattleOutcome
    {
        Ongoing,
        Victory,  // Attacking fleet wins
        Defeat,   // Defending station or fleet holds
        Draw      // Mutual destruction or stalemate
    }
}
