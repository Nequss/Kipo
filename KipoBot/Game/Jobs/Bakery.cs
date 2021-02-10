using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Jobs
{
    class Bakery : Work
    {
        public Bakery(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner, ctx)
        {
            name = "Bakery";
            reward = 35;
            energyCost = 20;
            thirstCost = 15;
            hungerCost = 10;
            happinessCost = 13;
            timeDuration = 1;
            xpReward = 20;
            reqStage = Pet.Stage.Teenager;
            proceed();
        }
    }
}