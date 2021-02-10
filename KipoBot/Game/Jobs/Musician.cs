using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Jobs
{
    class Musician : Work
    {
        public Musician(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner, ctx)
        {
            name = "Musician";
            reward = 200;
            energyCost = 40;
            thirstCost = 27;
            hungerCost = 15;
            happinessCost = 10;
            timeDuration = 4;
            xpReward = 50;
            reqStage = Pet.Stage.Teenager;
            proceed();
        }
    }
}