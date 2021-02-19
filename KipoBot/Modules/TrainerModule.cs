using Discord;
using Discord.Webhook;
using Discord.WebSocket;
using Discord.Commands;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using KipoBot.Services;
using KipoBot.Game.Base;
using System.Reflection;
using KipoBot.Utils;

namespace KipoBot.Modules
{
    [Group("t")]
    [Name("trainer")]
    [Summary("Train pettos! Get new abilities for pettos and such!")]
    public class TrainerModule : ModuleBase<SocketCommandContext>
    {
        private readonly DatabaseService database;

        public TrainerModule(DatabaseService _database)
        {
            database = _database;
        }

        [Command("abilities", RunMode = RunMode.Async)]
        [Summary("No description")]
        public async Task Abilities()
        {
            Player player = await database.PlayerInfo(Context.User.Id);

            if (player != null)
            {
                EmbedBuilder embedBuilder = new EmbedBuilder();

                embedBuilder.Color = Color.Purple;

                foreach (var ability in database.abilities)
                    embedBuilder.AddField($"{ability.name} | {ability.price} ₭", $"{ability.description}");

                await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
            }
            else
            {
                await Context.Channel.SendMessageAsync("You are not a member of the Kipo's tamagotchi club.\n" +
                    "You can join by choosing your first pet, try +help starters");
            }
        }
    }
}
