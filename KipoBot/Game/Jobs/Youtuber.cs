using System;
using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Jobs
{
    [Serializable]
    class Youtuber : Work
    {
        public Youtuber(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner)
        {
            name = "Youtuber";
            reward = 130;
            energyCost = 50;
            thirstCost = 27;
            hungerCost = 20;
            happinessCost = 15;
            timeDuration = 3;
            xpReward = 40;
            reqStage = Pet.Stage.Teenager;

            if (pet != null)
                proceed(ctx);
        }
    }
}