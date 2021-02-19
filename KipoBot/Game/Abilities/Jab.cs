using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class Jab : Ability
    {
        public Jab()
        {
            name = "Jab";
            description = "Jabs the sucker";
            price = 500;
        }

        public override int Use(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}