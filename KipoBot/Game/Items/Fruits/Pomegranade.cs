using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Pomegranade :Item
    {
        public Pomegranade()
        {
            type = Type.Fruit;
            price = 60;
            name = "Pomegranade";
            description = "BE CAREFULL IT’S A GRANADE  ";
            hunger = 50;
        }
    }
}
