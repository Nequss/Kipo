using System;

namespace KipoBot.Game.Base
{
    [Serializable]
    public abstract class Item
    {
        public enum Type
        {
            Toy,
            Potion,
            Meat,
            Vegetable,
            Berry,
            Drink,
            Fruit,
            Treat,
            Tool,
            Weapons
        }

        public string name;
        public string description;
        public Type   type;
        public short  price;
        public ulong? owner = null;

        public byte hapiness = 0;
        public byte health   = 0;
        public byte hunger   = 0;
        public byte thirst   = 0;
        public byte energy   = 0;
    }
}
