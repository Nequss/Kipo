using System;
using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Jobs
{
    [Serializable]
    class Construction : Work
    {
        public Construction(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner)
        {
            name = "Construction";
            reward = 25;
            energyCost = 15;
            thirstCost = 10;
            hungerCost = 5;
            happinessCost = 10;
            timeDuration = 1;
            reqStage = Pet.Stage.Teenager;
            proceed(ctx);
        }
    }
}