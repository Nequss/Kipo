using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Jobs
{
    class Factory : Work
    {
        public Factory(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner, ctx)
        {
            name = "Factory";
            reward = 25;
            energyCost = 10;
            thirstCost = 10;
            hungerCost = 5;
            happinessCost = 10;
            timeDuration = 1;
            reqStage = Pet.Stage.Baby;
            proceed();
        }
    }
}