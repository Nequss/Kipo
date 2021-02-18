using System;
using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Jobs
{
    [Serializable]
    class Fighter : Work
    {
        public Fighter(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner)
        {
            name = "Fighter";
            reward = 130;
            energyCost = 50;
            thirstCost = 31;
            hungerCost = 20;
            happinessCost = 15;
            timeDuration = 2;
            xpReward = 30;
            reqStage = Pet.Stage.Adult;

            if (pet != null)
                proceed(ctx);
        }

        public bool meetsAdditionalReqs(SocketCommandContext ctx)
        {
            return worker.strength >= 30;
        }

        public void workCompleted()
        {
            worker.health -= 10;
            base.workCompleted();
        }
    }
}