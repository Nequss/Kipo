using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class Mango : Item
    {
        public Mango()
        {
            type = Type.Fruit;
            price = 55;
            name = "Mango";
            description = "You can read it.. Oh wait this is a fruit that is tasty and juicy ";
            hunger = 35;
        }
    }
}
