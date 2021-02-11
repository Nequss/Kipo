using System;
using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Jobs
{
    [Serializable]
    class DeliveryServices : Work
    {
        public DeliveryServices(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner)
        {
            name = "Delivery Services";
            reward = 75;
            energyCost = 20;
            thirstCost = 10;
            hungerCost = 22;
            happinessCost = 20;
            timeDuration = 2;
            xpReward = 30;
            reqStage = Pet.Stage.Adult;
            proceed(ctx);
        }
    }
}