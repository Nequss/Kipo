using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class QuickHit : Ability
    {
        public QuickHit()
        {
            name = "Quick Hit";
            description = "Fast as heck!";
            price = 200;
        }

        public override int Use(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}