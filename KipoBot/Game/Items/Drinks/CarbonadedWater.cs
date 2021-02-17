using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Drinks
{
    [Serializable]
    class CarbonatedWater : Item
    {
        public CarbonatedWater()
        {
            type = Type.Drink;
            price = 15;
            name = "Carbonated water";
            description = "Water with bubbles!!!";
            thirst = 5;
        }
    }
}