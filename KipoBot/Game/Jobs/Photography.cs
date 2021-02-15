using System;
using System.Runtime.CompilerServices;
using Discord.Commands;
using KipoBot.Game.Base;
using KipoBot.Game.Items.Tools;

namespace KipoBot.Game.Jobs
{
    [Serializable]
    class Photography : Work
    {
        public Photography(Pet pet, Player owner, SocketCommandContext ctx) : base(pet, owner)
        {
            name = "Photography";
            reward = 120;
            //energyCost = 30;
            //thirstCost = 27;
            //hungerCost = 20;
            //happinessCost = 20;
            timeDuration = 3;
            xpReward = 40;
            reqStage = Pet.Stage.Baby;
            setReqItem<Camera>();
            proceed(ctx);
        }
    }
}