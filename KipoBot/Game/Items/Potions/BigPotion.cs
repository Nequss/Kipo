using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Potions
{
    [Serializable]
    class BigPotion : Item
    {
        public BigPotion()
        {
            type = Type.Potion;
            price = 500;
            name = "Big Potion";
            describtion = "This somehow weirdly heals a lot of your pets wounds";
            health = 200;
        }
    }
}