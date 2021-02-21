using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Abilities
{
    [Serializable]
    public class BackFist : Ability
    {
        public BackFist()
        {
            name = "Back Fist";
            description = "Little bit more damage than normal punch";
            price = 70;
        }

        public override int Use(Pet attacker, Pet target)
        {
            throw new NotImplementedException();
        }
    }
}