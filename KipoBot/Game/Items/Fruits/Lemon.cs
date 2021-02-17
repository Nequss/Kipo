using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Lemon : Item
    {
        public Lemon()
        {
            type = Type.Fruit;
            price = 20;
            name = "Lemon";
            description = "Very sour that’s all you need to know";
            hunger = 10;
        }
    }
}