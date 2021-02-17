using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Meats
{
    [Serializable]
    class OxTongue : Item
    {
        public OxTongue ()
        {
            type = Type.Meat;
            price = 35;
            name = "Ox tongue";
            description = "Name self explanatory  ";
            hunger = 25;
        }
    }
}