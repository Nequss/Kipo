using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Berries
{
    [Serializable]
    class Gooseberry : Item
    {
        public Gooseberry()
        {
            type = Type.Berry;
            price = 10;
            name = "Cranberry";
            description = "Illegal in some coutries but is a great berrry with vitamins and sweet taste inside and sour skin";
            hunger = 5;
        }
    }
}