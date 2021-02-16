using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Clementine : Item
    {
        public Clementine()
        {
            type = Type.Fruit;
            price = 20;
            name = "Clementine";
            description = "Citrus fruit hybrid between a willowleaf mandarin orange  and a sweet orange";
            hunger = 12;
        }
    }
}
