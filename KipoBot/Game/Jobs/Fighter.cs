using System;
using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Jobs
{
    [Serializable]
    class Fighter : Work
    {
        public Fighter(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner, ctx)
        {
            name = "Fighter";
            reward = 130;
            energyCost = 20;
            thirstCost = 31;
            hungerCost = 20;
            happinessCost = 15;
            timeDuration = 2;
            xpReward = 30;
            reqStage = Pet.Stage.Adult;
            proceed();
        }

        public bool meetsAdditionalReqs()
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