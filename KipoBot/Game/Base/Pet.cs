using System;

namespace KipoBot.Game.Base
{
    [Serializable]
    public abstract class Pet
    {
        public static int updateIntervalMS = 1000*60*60;
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
        public DateTime nextUpdateTime;
        public bool isAsleep = false;
         
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
            nextUpdateTime = DateTime.Now + new TimeSpan(0, 0, 0,0 ,updateIntervalMS);
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

        public string getWorkInfo()
        {
            if (hasWork())
            {
                return currentWork.getWorkInfo();
            }

            return "Job: None";
        }

        public void performUpdate(DateTime timeNow)
        {
            if (!(DateTime.Compare(timeNow, nextUpdateTime) >= 0))
                return;

            if (isAsleep)
            {
                thirst = (byte) (thirst - 1 >= 0 ? thirst - 1 : 0);
                hunger = (byte) (hunger - 1 >= 0 ? hunger - 1 : 0);
                hapiness = (byte) (hapiness - 6 >= 0 ? hapiness - 6 : 0); 
                
                if (thirst == 0 || hunger == 0 || hapiness == 0)
                {
                    health = (byte) (health - 6 >= 0 ? health - 6 : 0);
                }
            }
            else
            {
                thirst = (byte) (thirst - 5 >= 0 ? thirst - 5 : 0);
                hunger = (byte) (hunger - 5 >= 0 ? hunger - 5 : 0);

                if (thirst == 0 || hunger == 0 || hapiness == 0)
                {
                    health = (byte) (health - 10 >= 0 ? health - 10 : 0);
                    hapiness = (byte) (hapiness - 6 >= 0 ? hapiness - 6 : 0);
                    
                }
                else
                {
                    hapiness = (byte) (hapiness - 3 >= 0 ? hapiness - 3 : 0);
                }

                energy = (byte) (energy + 15 + level / 2 >= getMaxEnergy(level) ? energy + 15 + level / 2 : getMaxEnergy(level));
            }

            nextUpdateTime = timeNow + new TimeSpan(0, 0, 0, 0, updateIntervalMS);
            Program.Logger.info($"Next update in: {nextUpdateTime}");
        }
    }
}
