using System;
using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Jobs
{
    [Serializable]
    class Office : Work
    {
        public Office(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner)
        {
            name = "Office";
            reward = 75;
            energyCost = 30;
            thirstCost = 15;
            hungerCost = 20;
            happinessCost = 22;
            timeDuration = 2;
            xpReward = 30;
            reqStage = Pet.Stage.Adult;
            proceed(ctx);
        }
    }
}