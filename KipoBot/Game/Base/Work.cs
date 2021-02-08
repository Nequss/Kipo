using System;
using Discord.Commands;

namespace KipoBot.Game.Base
{
    [Serializable]
    public abstract class Work
    {
        public int reward;
        public String name;
        public byte energyCost;
        public byte thirstCost;
        public byte hungerCost;
        public byte happinessCost;
        public byte timeDuration;
        public Pet worker;
        public Pet.Stage reqStage;
        public Item reqItem;
        public DateTime timeStarted;
        public DateTime timeEnd;
        public Player workerOwner;
        public SocketCommandContext context;

        protected Work(Pet pet, Player owner, SocketCommandContext ctx)
        {
            worker = pet;
            worker.currentWork = this;
            workerOwner = owner;
            context = ctx;
        }

        public bool isOldEnough()
        {
            return worker.stage >= reqStage;
        }

        public bool hasReqItem()
        {
            foreach (var item in workerOwner.items)
            {
                if (item.GetType() == reqItem.GetType())
                {
                    return true;
                }
            }

            return false;
        }

        public void workCompleted()
        {
            context.Channel.SendMessageAsync($"{worker.name} has finished!\n{workerOwner.id} had {workerOwner.wallet} money.");
            worker.energy -= energyCost;
            workerOwner.wallet += reward;
            worker.currentWork = null;
            context.Channel.SendMessageAsync($"Now has {workerOwner.wallet} money.");
        }

        public void workStarted()
        {
            timeStarted = DateTime.Now;
            timeEnd = timeStarted + new TimeSpan(timeDuration,0,0);
            context.Channel.SendMessageAsync($"Work started at: {timeStarted}\nWill end at: {timeEnd}\nTime remaining: {timeEnd.Subtract(timeStarted)}");
        }

        public bool satisfiesReqs()
        {
            if (worker.energy < energyCost)
                return false;

            if (worker.thirst < thirstCost)
                return false;
            
            if (worker.hunger < hungerCost)
                return false; 
            
            if (worker.hapiness < happinessCost)
                return false;

            return true;
        }

        public void verify()
        {
            if (!isOldEnough())
            {
                context.Channel.SendMessageAsync($"This work requires your pet to be at least at stage: {reqStage}\nCome back when it gets older!");
                return;
            }
            
            if (reqItem != null && !hasReqItem())
            {
                //context.Channel.SendMessageAsync($"This work requires an item that you currently don't have: {reqItem}\nCome back when you have it!");
                //return;
            }

            satisfiesReqs();
            workStarted();
            context.Channel.SendMessageAsync($"{worker.name} started job: {name}");
            workCompleted();
        }
    }
}