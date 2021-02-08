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
        public byte timeDuration;
        public Pet worker;
        public Pet.Stage reqStage;
        public Item reqItem;
        public DateTime timeStarted;
        public DateTime timeEnd;
        public Player workerOwner;

        protected Work(Pet pet, Player owner, SocketCommandContext ctx)
        {
            worker = pet;
            worker.currentWork = this;
            workerOwner = owner;
            
            if (!canWork())
            {
                ctx.Channel.SendMessageAsync($"This work requires your pet to be at least at stage: {reqStage}\nCome back when it gets older!");
                return;
            }
            
            if (reqItem != null && !hasReqItem())
            {
                ctx.Channel.SendMessageAsync($"This work requires an item that you currently don't have: {reqItem}\nCome back when you have it!");
                //return;
            }

            workStarted();
            ctx.Channel.SendMessageAsync($"{pet.name} started job: {name}");
            workCompleted();
        }

        public bool canWork()
        {
            return worker.stage >= reqStage && hasReqItem();
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
            Console.WriteLine($"{worker.name} has finished!\n{workerOwner.id} had {workerOwner.wallet} money.");
            worker.energy -= energyCost;
            workerOwner.wallet += reward;
            worker.currentWork = null;
            Console.WriteLine($"Now has {workerOwner.wallet} money.");
        }

        public void workStarted()
        {
            timeStarted = DateTime.Now;
            timeEnd = timeStarted + new TimeSpan(timeDuration,0,0);
            Console.WriteLine($"Work started at: {timeStarted}\nWill end at: {timeEnd}\nTime remaining: {timeEnd.Subtract(timeStarted)}");
        }
    }
}