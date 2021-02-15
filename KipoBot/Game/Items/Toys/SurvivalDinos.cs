using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class SurvivalDinos : Item
    {
        public SurvivalDinos()
        {
            type = Type.Toy;
            price = 55;
            name = "Survival Dinos";
            description = "Build houses, create civilizations, tame dinos and much more";
            hapiness = 40;
        }
    }
}
