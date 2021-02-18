using System;
using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Jobs
{
    [Serializable]
    class PersonalDriver : Work
    {
        public PersonalDriver(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner)
        {
            name = "Personal Driver";
            reward = 200;
            energyCost = 60;
            thirstCost = 31;
            hungerCost = 25;
            happinessCost = 29;
            timeDuration = 4;
            xpReward = 50;
            reqStage = Pet.Stage.Adult;

            if (pet != null)
                proceed(ctx);
        }
    }
}