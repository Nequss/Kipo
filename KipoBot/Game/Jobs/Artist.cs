using System;
using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Jobs
{
    [Serializable]
    class Artist : Work
    {
        public Artist(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner)
        {
            name = "Artist";
            reward = 120;
            energyCost = 50;
            thirstCost = 27;
            hungerCost = 20;
            happinessCost = 16;
            timeDuration = 3;
            xpReward = 40;
            reqStage = Pet.Stage.Teenager;

            if (pet != null)
                proceed(ctx);
        }
    }
}