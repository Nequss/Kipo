using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class SideKick : Ability
    {
        public SideKick()
        {
            name = "Side Kick";
            description = "Kicks side of enemy stand";
            price = 200;
        }

        public override int Use(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}