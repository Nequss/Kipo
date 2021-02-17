using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Grapefruits : Item
    {
        public Grapefruits()
        {
            type = Type.Fruit;
            price = 15;
            name = "Grapefruits";
            description = "Firm, well shaped fruit that is heavy for its size, taste amazing ";
            hunger = 5;
        }
    }
}
