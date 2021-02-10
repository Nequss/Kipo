using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Potions
{
    [Serializable]
    class SmollPotion : Item
    {
        public SmollPotion()
        {
            type = Type.Potion;
            price = 100;
            name = "Smoll Potion";
            description = "Just enought to get back from little quarrel";
            health = 20;
        }
    }
}

