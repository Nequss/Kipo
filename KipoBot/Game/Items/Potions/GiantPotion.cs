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
            describtion = "Oh ma gahd your pets feel so good after it!";
            health = 200;
        }

        public override Pet Use(Pet pet)
        {
            return pet;
        }
    }
}