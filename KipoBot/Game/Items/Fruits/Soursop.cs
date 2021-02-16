using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Soursop : Item
    {
        public Soursop ()
        {
            type = Type.Fruit;
            price = 30;
            name = "Soursop";
            description = " High in vitamin C, an antioxidant known to boost immune health. ";
            hunger = 20;
        }
    }
}
    