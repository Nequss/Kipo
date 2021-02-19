using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class Punch : Ability
    {
        public Punch()
        {
            name = "Punch";
            description = "Punch enemy like desk after raging";
            price = 20;
        }

        public override int Use(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}