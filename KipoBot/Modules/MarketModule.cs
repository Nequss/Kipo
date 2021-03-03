using Discord;
using Discord.Webhook;
using Discord.WebSocket;
using Discord.Commands;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using KipoBot.Services;
using KipoBot.Game.Base;

namespace KipoBot.Modules
{
    [Group("t")]
    [Name("market")]
    [Summary("List your valuable things on market for other players.")]
    public class MarketModule : ModuleBase<SocketCommandContext>
    {
        private readonly DatabaseService database;

        public MarketModule(DatabaseService _database)
        {
            database = _database;
        }

        [Command("market add", RunMode = RunMode.Async)]
        [Summary("lists item")]
        public async Task List(string price, [Remainder] string itemID)
        {
            int _itemID;
            int _price;

            if (!Int32.TryParse(itemID, out _itemID))
            {
                await Context.Channel.SendMessageAsync("Item not found");
                return;
            }

            if (!Int32.TryParse(price, out _price))
            {
                await Context.Channel.SendMessageAsync("Invalid price");
                return;
            }

            Player player = await database.FindPlayer(Context.Message.Author.Id);

            if (player != null)
            {
                for (int i = 0; i < player.items.Count; i++)
                {
                    if (_itemID == i)
                    {
                        var item = player.items[i];
                        item.owner = player.id;
                        item.price = (short)_price;
                        database.market.Add(item);
                        player.items.Remove(item);
                        await Context.Channel.SendMessageAsync($"{item.name} has been listed for {_price}₭");
                        return;
                    }
                }

                await Context.Channel.SendMessageAsync("Item not found");
                return;
            }
            else
            {
                await Context.Channel.SendMessageAsync("You are not a member of the Kipo's tamagotchi club.\n" +
                    "You can join by choosing your first pet, try +help starters");
            }
        }

        [Command("market remove", RunMode = RunMode.Async)]
        [Summary("unlists item")]
        public async Task Unlist([Remainder] string itemID)
        {
            int _itemID;

            if (!Int32.TryParse(itemID, out _itemID))
            {
                await Context.Channel.SendMessageAsync("Item not found");
                return;
            }

            Player player = await database.FindPlayer(Context.Message.Author.Id);

            if (player != null)
            {
                for (int i = 0; i < database.market.Count; i++)
                {
                    if (_itemID == i)
                    {
                        if (database.market[i].owner == player.id)
                        {
                            var item = database.market[i];
                            item.owner = null;
                            item.price = 0;
                            player.items.Add(item);
                            database.market.Remove(item);
                            await Context.Channel.SendMessageAsync($"{item.name} has been unlisted and added to backpack");
                            return;
                        }
                    }
                }

                await Context.Channel.SendMessageAsync("Item not found");
                return;
            }
            else
            {
                await Context.Channel.SendMessageAsync("You are not a member of the Kipo's tamagotchi club.\n" +
                    "You can join by choosing your first pet, try +help starters");
            }
        }

        [Command("market buy", RunMode = RunMode.Async)]
        [Summary("unlists item")]
        public async Task MarketBuy([Remainder] string itemID)
        {
            int _itemID;

            if (!Int32.TryParse(itemID, out _itemID))
            {
                await Context.Channel.SendMessageAsync("Item not found");
                return;
            }

            Player player = await database.FindPlayer(Context.Message.Author.Id);

            if (player != null)
            {
                for (int i = 0; i < database.market.Count; i++)
                {
                    if (_itemID == i)
                    {
                        if (player.wallet >= database.market[i].price)
                        {
                            var item = database.market[i];
                            item.owner = null;
                            player.wallet -= database.market[i].price;
                            item.price = 0;
                            player.items.Add(item);
                            database.market.Remove(item);
                            await Context.Channel.SendMessageAsync($"{item.name} has been bought!");
                            return;
                        }

                        await Context.Channel.SendMessageAsync("Not enough ₭ipons to buy that item");
                        return;
                    }
                }

                await Context.Channel.SendMessageAsync("Item not found");
                return;
            }
            else
            {
                await Context.Channel.SendMessageAsync("You are not a member of the Kipo's tamagotchi club.\n" +
                    "You can join by choosing your first pet, try +help starters");
            }
        }

        [Command("market all", RunMode = RunMode.Async)]
        [Summary("unlists item")]
        public async Task MarketAll()
        {
            if (database.market.Count == 0)
            {
                await Context.Channel.SendMessageAsync("Market is empty");
                return;
            }

            EmbedBuilder embedBuilder = new EmbedBuilder();

            string text = "";

            embedBuilder.Color = Color.Purple;
            embedBuilder.WithAuthor(author =>
            {
                author.WithName($"Market | Kipo's tamagotchi club");
                author.WithIconUrl(Context.Client.CurrentUser.GetAvatarUrl());
            });

            for(int i = 0; i < database.market.Count; i++)
                text += $"{i} | {database.market[i].name} | {database.market[i].price}₭";

            embedBuilder.AddField("ID | Name | Price", text);

            await Context.Channel.SendMessageAsync(embed: embedBuilder.Build());
        }
    }
}
