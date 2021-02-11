using System;
using KipoBot.Game.Base;

namespace KipoBot.Game.Pets
{
    [Serializable]
    class Dog : Pet
    {
        public Dog()
        {
            type = Type.Dog;
            name = "Dog";

            health = 50;
            hunger = 20;
            thirst = 20;
            energy = 10;

            speed = 10;
            inteligence = 15;
            strength = 10;
            agility = 10;
            accuracy = 10;
        }

        public override byte getMaxHealth(byte level) => (byte)(50 + level);

        public override short getMaxEnergy(byte level) => (short)((10 + level) * 2);

        public override byte getMaxHunger() => 20;

        public override byte getMaxThirst() => 20;
    }
}
