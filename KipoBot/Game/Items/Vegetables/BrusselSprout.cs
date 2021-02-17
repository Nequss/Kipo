using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class BrusselSprout : Item
    {
        public BrusselSprout()
        {
            type = Type.Vegetable;
            price = 20;
            name = "Bamboo";
            description = "Small little lettuce thingies ";
            hunger = 10;
        }
    }
}