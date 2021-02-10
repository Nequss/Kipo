using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Potions
{
    [Serializable]
    class GiantPotion : Item
    {
        public GiantPotion()
        {
            type = Type.Potion;
            price = 800;
            name = "Giant Potion";
            description = "Oh ma gahd your pets feel so good after it!";
            health = 200;
        }
    }
}