using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Plump : Item
    {
        public Plump ()
        {
            type = Type.Fruit;
            price = 10;
            name = "Plump";
            description = "Full of fiber and good for your skeleton bones  ";
            hunger = 5;
        }
    }
}
