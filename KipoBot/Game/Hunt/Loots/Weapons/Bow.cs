using KipoBot.Game.Base;
using System;

namespace KipoBot.Game.Hunt.Loots
{
    [Serializable]
    public class Bow : Item
    {
        public Bow()
        {
            type = Type.Weapon;
            name = "Bow";
            description = " Shoot enemies from a far with bow and arrow";
            price = 100;
            damage = 1;
        }
    }
}