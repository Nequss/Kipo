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
            description = "Little bit more damage and it's like normal punch";
            price = 70;
        }

        public override int Use(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}