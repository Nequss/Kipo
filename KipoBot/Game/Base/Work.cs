using System;
using Discord;
using Discord.Commands;

namespace KipoBot.Game.Base
{
    [Serializable]
    public abstract class Work
    {
        public int reward;
        public int xpReward;
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
        public bool markedForDeletion { get; protected set;}

        protected Work(Pet pet, Player owner, SocketCommandContext ctx)
        {
            worker = pet;
            worker.currentWork = this;
            workerOwner = owner;
            context = ctx;
            markedForDeletion = false;
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
            worker.thirst -= thirstCost;
            worker.hunger -= hungerCost;
            worker.hapiness -= happinessCost;
            worker.xp += xpReward;
            workerOwner.wallet += reward;
            context.Channel.SendMessageAsync($"Now has {workerOwner.wallet} money.");
            removeWork();
        }

        public void removeWork()
        {
            worker.currentWork = null;
            markedForDeletion = true;
        }

        public void beginWork()
        {
            //TODO ADD TO LIST OF ACTIVE JOBS
            
            timeStarted = DateTime.Now;
            timeEnd = timeStarted + new TimeSpan(timeDuration,0,0);
            context.Channel.SendMessageAsync($"Work started at: {timeStarted}\nWill end at: {timeEnd}\nTime remaining: {timeEnd.Subtract(timeStarted)}");
        }

        public bool satisfiesReqs()
        {
            if (worker.energy < energyCost)
            {
                context.Channel.SendMessageAsync($"{worker.name} does not meet energy requirements.");
                removeWork();
                return false;
            }

            if (worker.thirst < thirstCost)
            {
                context.Channel.SendMessageAsync($"{worker.name} does not meet thirst requirements.");
                removeWork();
                return false;
            }

            if (worker.hunger < hungerCost)
            {
                context.Channel.SendMessageAsync($"{worker.name} does not meet hunger requirements.");
                removeWork();
                return false;
            }

            if (worker.hapiness < happinessCost)
            {
                context.Channel.SendMessageAsync($"{worker.name} does not meet happiness requirements.");
                removeWork();
                return false;
            }

            return true;
        }

        public void proceed()
        {
            if (!isOldEnough())
            {
                context.Channel.SendMessageAsync($"This work requires your pet to be at least at stage: {reqStage}\nCome back when it gets older!");
                removeWork();
                return;
            }
            
            if (reqItem != null && !hasReqItem())
            {
                //TODO Check if pet owner has required item
                //context.Channel.SendMessageAsync($"This work requires an item that you currently don't have: {reqItem}\nCome back when you have it!");
                //removeWork();
                //return;
            }

            if (!satisfiesReqs())
            {
                removeWork();
                return;
            }

            beginWork();
            context.Channel.SendMessageAsync($"{worker.name} started job: {name}");
            workCompleted();
            removeWork();
        }

        public void quitWork()
        {
            //TODO STOP WORKING
        }
    }
}