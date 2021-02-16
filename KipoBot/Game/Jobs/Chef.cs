using System;
using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Jobs
{
    [Serializable]
    class Chef : Work
    {
        public Chef(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner)
        {
            name = "Chef";
            reward = 120;
            energyCost = 50;
            thirstCost = 29;
            hungerCost = 18;
            happinessCost = 25;
            timeDuration = 3;
            xpReward = 40;
            reqStage = Pet.Stage.Adult;
            proceed(ctx);
        }
    }
}