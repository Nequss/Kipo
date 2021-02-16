using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Berries
{
    [Serializable]
    class OregonGrape : Item
    {
        public OregonGrape()
        {
            type = Type.Berry;
            price = 22;
            name = "Oregon grape";
            description = "grape from oregon";
            hunger = 12;
        }
    }
}