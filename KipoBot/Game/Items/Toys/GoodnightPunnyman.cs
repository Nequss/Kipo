using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Toys
{
    [Serializable]
    class GoodNightPunnyman : Item
    {
        public GoodNightPunnyman()
        {
            type = Type.Toy;
            price = 50;
            name = "Goodnight Punnyman";
            description = "Read a amazing story about life of a white bird";
            hapiness = 20;
            energy = 5;
        }
    }
}
