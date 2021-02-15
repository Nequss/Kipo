using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class GrandQuestAuto : Item
    {
        public GrandQuestAuto()
        {
            type = Type.Toy;
            price = 55;
            name = "GrandQuestAuto";
            description = "Let your pet go on quest not only in his life but also in game";
            hapiness = 40;
        }
    }
}
