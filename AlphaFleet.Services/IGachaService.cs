using AlphaFleet.Data.Models;
using AlphaFleet.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaFleet.Services
{
    public interface IGachaService
    {
        ShipRarity RollRarity();
        Ship PullShip();
    }
}
