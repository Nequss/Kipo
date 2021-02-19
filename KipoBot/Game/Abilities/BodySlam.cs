using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class BodySlam : Ability
    {
        public BodySlam()
        {
            name = "Body Slam";
            description = "Body slams enemy, double the damage, has chance of impacting you instead ";
            price = 2000;
        }

        public override int Use(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}