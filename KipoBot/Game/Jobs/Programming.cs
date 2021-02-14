using System;
using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Jobs
{
    [Serializable]
    class Programming : Work
    {
        public Programming(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner)
        {
            name = "Programming";
            reward = 75;
            energyCost = 20;
            thirstCost = 23;
            hungerCost = 15;
            happinessCost = 15;
            timeDuration = 2;
            xpReward = 30;
            reqStage = Pet.Stage.Adult;
            proceed(ctx);
        }
    }
}