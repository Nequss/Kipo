using KipoBot.Game.Base;
using System;

namespace KipoBot.Game.Hunt.Enemies
{
    public class Fred : Pet
    {
        public Fred()
        {
            name = "Fred";
            health = 25;
            damage = 5;
            reward = 20;
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
