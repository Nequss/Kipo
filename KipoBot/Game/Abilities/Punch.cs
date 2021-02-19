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
            description = "Punch your enemy like your desk after raging";
            price = 20;
        }

        public override int Use(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}