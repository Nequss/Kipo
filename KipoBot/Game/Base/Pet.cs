namespace KipoBot.Game.Base
{
    public abstract class Pet
    {
        public enum Rarity
        {
            Common,
            Uncommon,
            Rare,
            Legendary
        }

        public enum Stage
        {
            Baby,
            Toddler,
            Teenager,
            Adult
        }

        public enum Type
        {
            Dog,
            Cat,
            Lizard,
            Hamster,
            Bunny,
            Snake,
            Bird
        }

        public Rarity rarity;
        public Stage stage;
        public Type type;

        //default
        public byte hapiness;
        public byte level;
        public int xp;
        public Work currentWork = null;
        public Item tool = null;
         
        //to set
        public string name;
        public byte health;
        public short hunger;
        public short thirst;
        public short energy;
        public byte speed;
        public byte inteligence;
        public byte strength;
        public byte agility;
        public byte accuracy;

        protected Pet()
        {
            rarity = Rarity.Common;
            stage = Stage.Baby;
            hapiness = 25;
            level = 1;
            xp = 0;
        }

        public abstract byte  getMaxHealth(byte level);
        public abstract short getMaxEnergy(byte level);
        public abstract byte  getMaxThirst();
        public abstract byte  getMaxHunger();
        public byte getBaseHapiness() => 25;

        public void Use(Item item)
        {
            if (item.type != Item.Type.Tool)
            {
                hapiness = (byte)(item.hapiness + hapiness > getBaseHapiness() ? getBaseHapiness() : item.hapiness + hapiness);
                health   = (byte)(item.health + health > getMaxHealth(level) ? getMaxHealth(level) : item.health + health);
                hunger   = (byte)(item.hunger + hunger > getMaxHunger() ? getMaxHunger() : item.hunger + hunger);
                thirst   = (byte)(item.thirst + thirst > getMaxThirst() ? getMaxThirst() : item.thirst + thirst);
                energy  =  (byte)(item.energy + energy > getMaxEnergy(level) ? getMaxEnergy(level) : item.energy + energy);
            }
            else
            {
                tool = item;
            }
        }

        public bool hasWork()
        {
            return currentWork != null;
        }
    }
}
