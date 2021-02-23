using System;
using System.Collections.Generic;
using System.Text;
using Discord.WebSocket;
using Discord.Commands;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using KipoBot.Services;
using KipoBot.Game.Base;
using KipoBot.Utils;
using Discord.Addons.Interactive;
using Discord;

namespace KipoBot.Modules
{
    [Name("Minigames")]
    [Summary("Contains all fun minigames to play")]
    public class MinigameModule : ModuleBase<SocketCommandContext>
    {
        private readonly InteractiveService interaction;

        public MinigameModule(InteractiveService _interaction)
        {
            interaction = _interaction;
        }

        [Command("Guess", RunMode = RunMode.Async)]
        [Summary("Play a number guesing game agaisnt Kipo +guess (your number)")]

        public async Task Guess(int x, SocketCommandContext ctx, SocketUser a)
        {
            await ReplyAsync("Kipo is thinking of a number between 1 to " + x + " try to guess it in 6 attempts");

            SocketMessage guess = await interaction.NextMessageAsync(ctx, new EnsureFromUserCriterion(a));


            int Playertries = 0;
            int attempts = 3;
            Random rnd = new Random();
            int num = rnd.Next(1, x + 1);
            bool end = false;
            decimal myDec;


            if (Result == false)
                await Context.Channel.SendMessageAsync("Your guess has to be a number");

            while (end == false) ;
            attempts--;

            if (Playertries != attempts && attempts == 0)
            {
                await ReplyAsync("You ran out of attempts and lost the game :c");
                end = true;
            }
            if (guess == num)
            {
                await Context.Channel.SendMessageAsync("You win! CONGRATS");
                end = true;
            }
            else if (guess > num && guess < num)
            {
                await Context.Channel.SendMessageAsync("Kipo is thinking of a different number try again you have" + attempts + " left ");
            }

            else
                await ReplyAsync("You didn't pick a number before the timeout");


        }
    }
}

