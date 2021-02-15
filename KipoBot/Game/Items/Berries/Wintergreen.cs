using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Berries
{
    [Serializable]
    class Wintergreen : Item
    {
        public Wintergreen()
        {
            type = Type.Berry;
            price = 18;
            name = "Wintergreen";
            description = "Perfect for small creatures and all those who love winter";
            hunger = 10;
        }
    }
}