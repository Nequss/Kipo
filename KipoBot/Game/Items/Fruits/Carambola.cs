using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Carambola : Item
    {
        public Carambola ()
        {
            type = Type.Fruit;
            price = 28;
            name = "Carambol";
            description = "STARFRUIT ";
            hunger = 18;
        }
    }
}
