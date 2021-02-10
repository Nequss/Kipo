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
            price = 5;
            name = "Cucumber";
            describtion = "Long, green and basically water but in vegetable porn with taste";
            hunger = 10;
        }
    }
}
