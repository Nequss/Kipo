using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Items.Fruits
{
    [Serializable]
    class HoneydewMelon : Item
    {
        public HoneydewMelon()
        {
            type = Type.Fruit;
            price = 55;
            name = "Honeydew Melon";
            description = " Low-sodium and potassium-rich fruit it's so good that it can even help your mental health ";
            hunger = 40;
        }
    }
}
