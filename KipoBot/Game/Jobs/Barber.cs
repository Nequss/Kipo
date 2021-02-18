using System;
using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Jobs
{
    [Serializable]
    class Barber : Work
    {
        public Barber(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner)
        {
            name = "Barber";
            reward = 25;
            energyCost = 15;
            thirstCost = 10;
            hungerCost = 5;
            happinessCost = 10;
            timeDuration = 1;
            xpReward = 20;
            reqStage = Pet.Stage.Teenager;

            if (pet != null)
                proceed(ctx);
        }
    }
}