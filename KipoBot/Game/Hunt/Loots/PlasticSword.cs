using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Vegetables
{
    [Serializable]
    class PlasticSword : Item
    {
        public PlasticSword()
        {
            type = Type.Weapons;
            price = 200;
            name = "Plastic sword";
            description = "Sword made out of strong plastic not safe for turtles ";
        }
    }
}
