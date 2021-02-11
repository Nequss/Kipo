using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Pets
{
    [Serializable]
    class Hamster : Pet
    {
        public Hamster()
        {
            type = Type.Hamster;
            name = "Hamster";

            health = 40;
            hunger = 25;
            thirst = 25;
            energy = 10;

            speed = 15;
            inteligence = 15;
            strength = 5;
            agility = 10;
            accuracy = 10;
        }

        public override byte getMaxHealth(byte level) => (byte)(40 + level);

        public override short getMaxEnergy(byte level) => (short)((10 + level) * 2);

        public override byte getMaxHunger() => 25;

        public override byte getMaxThirst() => 25;
    }
}
