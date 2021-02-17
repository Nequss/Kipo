using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class Liver : Item
    {
        public Liver()
        {
            type = Type.Meat;
            price = 25;
            name = "Liver";
            description = "A liver of something… ";
            hunger = 15;
        }
    }
}