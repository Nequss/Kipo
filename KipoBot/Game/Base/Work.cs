using System;
using Discord;
using Discord.Commands;
using KipoBot.Game.Items.Tools;
using KipoBot.Utils;

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
        public Type reqItem;
        public DateTime timeStarted;
        public DateTime timeEnd;
        public Player workerOwner;
        public bool markedForDeletion { get; protected set;}

        protected Work(Pet pet, Player owner)
        {
            worker = pet;
            worker.currentWork = this;
            workerOwner = owner;
            markedForDeletion = false;
        }

        public bool isOldEnough()
        {
            return worker.stage >= reqStage;
        }

        protected void setReqItem<T>()
        {
            reqItem = typeof(T);
        }

        public bool hasReqItem()
        {
            foreach (var item in workerOwner.items)
            {
                Program.Logger.info(item.GetType() + " " + reqItem);
                if (item.GetType() == reqItem)
                {
                    return true;
                }
            }

            return false;
        }

        public void workCompleted()
        {
            worker.energy -= energyCost;
            worker.thirst -= thirstCost;
            worker.hunger -= hungerCost;
            worker.hapiness -= happinessCost;
            worker.xp += xpReward;
            workerOwner.wallet += reward;
            removeWork();
        }

        public void removeWork()
        {
            worker.currentWork = null;
            workerOwner = null;
            markedForDeletion = true;
        }

        public void beginWork()
        {
            timeStarted = DateTime.Now;
            timeEnd = timeStarted + new TimeSpan(timeDuration,0,0);
            addToWorkList();
        }

        public bool satisfiesReqs(SocketCommandContext context)
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

        public void proceed(SocketCommandContext context)
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
                context.Channel.SendMessageAsync($"This work requires an item that you currently don't have: {reqItem}\nCome back when you have it!");
                removeWork();
                return;
            }

            if (!satisfiesReqs(context) || !meetsAdditionalReqs(context))
            {
                removeWork();
                return;
            }

            context.Channel.SendMessageAsync($"{worker.name} started job: {name}");
            beginWork();
        }

        public void quitWork()
        {
            removeWork();
        }

        protected bool meetsAdditionalReqs(SocketCommandContext context)
        {
            return true;
        }

        public  void addToWorkList()
        {
            lock (WorkManager.jobList)
            {
                WorkManager.jobList.Add(this);
            }
        }

        public string getWorkInfo()
        {
            return $"Job: {name}\nTime left: {timeEnd.Subtract(DateTime.Now)}";
        }
    }
}