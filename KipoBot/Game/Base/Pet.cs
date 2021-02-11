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

        public string Use(Item item)
        {
            switch (item.type)
            {
                case Item.Type.Berry:
                    return Eat(item);
                case Item.Type.Drink:
                    return Drink(item);
                case Item.Type.Fruit:
                    return Eat(item);
                case Item.Type.Meat:
                    return Eat(item);
                case Item.Type.Potion:
                    return RestoreHealth(item);
                case Item.Type.Tool:
                    tool = item;
                    return $"Pet has equiped {item.name} and is ready to work!";
                case Item.Type.Toy:
                    return RestoreHapiness(item);
                case Item.Type.Treat:
                    return RestoreHapiness(item);
                case Item.Type.Vegetable:
                    return Eat(item);
                default:
                    return "Item not found!";
            }
        }

        string Eat(Item item)
        {
            if (hunger + item.hunger > getMaxHunger())
            {
                hunger = getMaxHunger();
                return "Your pet's belly is now full!";
            }
            else
            {
                hunger = (byte)(hunger + item.hunger);
                return $"{item.name} restored {item.hunger} hunger. Current hunger: {hunger}/{getMaxHunger()}";
            }
        }

        string Drink(Item item)
        {
            string text = "";

            if (thirst + item.thirst > getMaxThirst())
            {
                thirst = getMaxThirst();
                text = "Pet's thirst has been fulfilled!";
            }
            else
            {
                thirst = (byte)(thirst + item.thirst);
                text = $"{item.name} restored {item.thirst} thirst. Current thirst: {thirst}/{getMaxThirst()}";
            }

            if (item.energy != 0)
            {
                if (energy + item.energy > getMaxEnergy(level))
                {
                    energy = getMaxEnergy(level);
                    text += $"\nPet is also full of energy! Thanks to {item.name}";
                }
                else
                {
                    energy = (byte)(energy + item.energy);
                    text += $"\n{item.name} restored {item.energy} energy. Current energy: {energy}/{getMaxEnergy(level)}";
                }
            }

            return text;
        }

        string RestoreHealth(Item item)
        {
            if (health + item.health > getMaxHealth(level))
            {
                health = getMaxHealth(level);
                return "Pet has full health now!";
            }
            else
            {
                health = (byte)(health + item.health);
                return $"{item.name} restored {item.health} health. Current health: {health}/{getMaxHealth(level)}";
            }
        }

        string RestoreHapiness(Item item)
        {
            if (hapiness + item.hapiness > getBaseHapiness())
            {
                hapiness = getBaseHapiness();
                return "Pet is fully happy now!";
            }
            else
            {
                hapiness = (byte)(hapiness + item.hapiness);
                return $"{item.name} restored {item.hapiness} hapiness. Current hapiness: {hapiness}/{getBaseHapiness()}";
            }
        }

        public bool hasWork()
        {
            return currentWork != null;
        }
    }
}
