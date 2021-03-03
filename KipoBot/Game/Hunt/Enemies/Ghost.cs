ususing KipoBot.Game.Base;
using System;

namespace KipoBot.Game.Hunt.Enemies
{
    public class Ghost : Pet
    {
        public Ghost()
        {
            name = "Stand";
            health = 20;
            damage = 4;
            reward = 15;
        }

        public override short getMaxEnergy(byte level)
        {
            throw new NotImplementedException();
        }

        public override byte getMaxHealth(byte level)
        {
            throw new NotImplementedException();
        }

        public override byte getMaxHunger()
        {
            throw new NotImplementedException();
        }

        public override byte getMaxThirst()
        {
            throw new NotImplementedException();
        }
    }
}
