using System;
using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Jobs
{
    [Serializable]
    class Driver : Work
    {
        public Driver(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner)
        {
            name = "Driver";
            reward = 75;
            energyCost = 20;
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