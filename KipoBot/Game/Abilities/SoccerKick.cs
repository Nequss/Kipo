using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class SoccerKick : Ability
    {
        public SoccerKick()
        {
            name = "Soccer Kick";
            description = "Soccer kicks the enemy like a ball, has more damage";
            price = 500;
        }

        public override int Use(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}