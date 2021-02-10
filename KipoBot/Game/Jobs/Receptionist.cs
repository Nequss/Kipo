using System;
using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;

namespace KipoBot.Game.Jobs
{
    [Serializable]
    class Receptionist : Work
    {
        public Receptionist(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner, ctx)
        {
            name = "Receptionist";
            reward = 25;
            energyCost = 10;
            thirstCost = 5;
            hungerCost = 5;
            happinessCost = 10;
            timeDuration = 1;
            xpReward = 20;
            reqStage = Pet.Stage.Teenager;
            proceed();
        }
    }
}