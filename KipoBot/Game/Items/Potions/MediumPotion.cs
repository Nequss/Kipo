using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Potions
{
    [Serializable]
    class MediumPotion : Item
    {
        public MediumPotion()
        {
            type = Type.Potion;
            price = 300;
            name = "Medium Potion";
            describtion = "Smoth tasting weird drink, your pets always wonder what it does";
            health = 50;
        }
    }
}