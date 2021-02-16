using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class Cucumber : Item
    {
        public Cucumber()
        {
            type = Type.Vegetable;
            price = 20;
            name = "Cucumber";
            description = "Long, green and basically water but in vegetable porn with taste";
            hunger = 10;
        }
    }
}
