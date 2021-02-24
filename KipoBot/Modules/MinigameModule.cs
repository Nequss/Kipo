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
        public async Task Guess(int x)
        {
            await ReplyAsync("Kipo is thinking of a number between 1 to "+x+" try to guess ");

           

            int parseResult;
            Random rnd = new Random();
            int num = rnd.Next(1, x + 1);
            int playertries = 3;
            bool end = true; 
            
            while (end == true)
            {
                playertries--;
                SocketMessage answer = await interaction.NextMessageAsync(Context);
                if (answer == null)
                {
                    await ReplyAsync("You didn't pick a number before the timeout");
                    return;
                }
                bool result = Int32.TryParse(answer.Content, out parseResult);

                if (result == false)
                {
                    await Context.Channel.SendMessageAsync("Your guess has to be a number");
                    return;
                }

                if (result == true)
                {
                    if (playertries == 0)
                    {
                        await Context.Channel.SendMessageAsync("You lost the game :c");
                        return;
                    }
                    if (parseResult == num)
                    {
                        await Context.Channel.SendMessageAsync("You win! CONGRATS");
                        return;
                    }
                    else
                    {
                        await ReplyAsync("Kipo is thinking of a different number try again you have " + playertries + " attemts left");
                    }
                }
               
            }
        }
    }
}

