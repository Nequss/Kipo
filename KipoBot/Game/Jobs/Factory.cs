using System;
using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;
using KipoBot.Game.Items.Berries;

namespace KipoBot.Game.Jobs
{
    [Serializable]
    class Factory : Work
    {
        public Factory(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner)
        {
            name = "Factory";
            reward = 25;
            energyCost = 10;
            thirstCost = 10;
            hungerCost = 5;
            happinessCost = 10;
            timeDuration = 1;
            xpReward = 20;
            setRequiredItem<Tomato>();
            reqStage = Pet.Stage.Baby;
            proceed(ctx);
        }
    }
}