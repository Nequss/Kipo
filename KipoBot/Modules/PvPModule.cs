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
using KipoBot.Utils;
using Discord.Addons.Interactive;

namespace KipoBot.Modules
{
    [Group("t")]
    [Name("pvp")]
    [Summary("Fight with pettos!")]
    public class PvPModule : ModuleBase<SocketCommandContext>
    {
        private readonly DatabaseService database;

        public PvPModule(DatabaseService _database)
        {
            database = _database;
        }

        [Command("challenge", RunMode = RunMode.Async)]
        [Summary("Fight with other owners\n+t challenge [user]")]
        public async Task Challenge([Remainder] string message)
        {
            Player p1 = await database.FindPlayer(Context.Message.Author.Id);

            if (p1 == null)
            {
                await Context.Channel.SendMessageAsync("You are not a member of the Kipo's tamagotchi club.\n" +
                    "You can join by choosing your first pet, try +help starters");
                return;
            }

            Player p2 = await database.FindPlayer(Helpers.extractUser(Context, message).Id);

            if (p2 == null)
            {
                await Context.Channel.SendMessageAsync("Your enemy is not a member of the Kipo's tamagotchi club.");
                return;
            }

            //new PvPLogic(Context, p1, p2);
        }

        [Command("pvp", RunMode = RunMode.Async)]
        [Summary("leaderboard")]
        public async Task PvP()
        {

        }

        [Command("testasync", RunMode = RunMode.Async)]
        public async Task Test_NextMessageAsync() => new PvPLogic(Context);
    }

    public class PvPLogic : InteractiveBase
    {
        Task Fight(SocketCommandContext ctx, Player p1, Player p2)
        {
            var response = NextMessageAsync();

            return Task.CompletedTask;
        }
        //public PvPLogic(SocketCommandContext ctx, Player p1, Player p2) => Fight(ctx, p1, p2);
        public PvPLogic(SocketCommandContext ctx) => Test(ctx);

        async Task Test(SocketCommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("type somethnig");

            var response = await NextMessageAsync();

            if (response != null)
                await ReplyAsync($"You replied: {response.Content}");
            else
                await ReplyAsync("PvP cancelled");
        }
    }
}