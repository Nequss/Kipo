using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Orange : Item
    {
        public Orange()
        {
            type = Type.Fruit;
            price = 10;
            name = "Orange";
            description = "Kinda the same as mandarin but BIG";
            hunger = 5;
        }
    }
}