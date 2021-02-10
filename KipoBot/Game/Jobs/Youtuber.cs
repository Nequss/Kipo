using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Jobs
{
    class Youtuber : Work
    {
        public Youtuber(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner, ctx)
        {
            name = "Youtuber";
            reward = 130;
            energyCost = 30;
            thirstCost = 27;
            hungerCost = 20;
            happinessCost = 15;
            timeDuration = 3;
            xpReward = 40;
            reqStage = Pet.Stage.Teenager;
            proceed();
        }
    }
}