using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class Bacon : Item
    {
        public Bacon()
        {
            type = Type.Meat;
            price = 10;
            name = "Bacon";
            describtion = "Meat from the back or sides of a pig that's cured and sliced";
            hunger = 5;
        }
    }
}