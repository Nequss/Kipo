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
using System.Collections.Generic;

namespace KipoBot.Modules
{
    [Group("t")]
    [Name("shop")]
    [Summary("Get food, drinks, accesories and other things for your pets and you.")]
    public class ShopModule : ModuleBase<SocketCommandContext>
    {
        private readonly DatabaseService database;

        public ShopModule(DatabaseService _database)
        {
            database = _database;
        }

        public async Task<EmbedBuilder[]> MakeEmbeds(List<Item> list, string category)
        {
            string stats;

            EmbedBuilder[] embedBuilders = new EmbedBuilder[(list.Count / 20) + 1];

            for (int i = 0; i < (list.Count / 20) + 1; i++)
            {
                embedBuilders[i] = new EmbedBuilder();
                embedBuilders[i].Color = Color.Purple;
                embedBuilders[i].WithAuthor(author =>
                {
                    author.WithName($"Shop - {category} | +t buy <name>");
                    author.WithIconUrl(Context.Client.CurrentUser.GetAvatarUrl());
                });

                for (int j = i * 20; j < (i + 1) * 20; j++)
                {
                    stats = "";

                    if (j >= list.Count)
                        break;

                    if (list[j].energy != 0)
                        stats += $"+{list[j].energy} energy\n";
                    if (list[j].hapiness != 0)
                        stats += $"+{list[j].hapiness} hapiness\n";
                    if (list[j].health != 0)
                        stats += $"+{list[j].health} health\n";
                    if (list[j].hunger != 0)
                        stats += $"+{list[j].hunger} hunger\n";
                    if (list[j].thirst != 0)
                        stats += $"+{list[j].thirst} thirst\n";

                    embedBuilders[i].AddField($"{list[j].name} | {list[j].price} ₭", $"{stats}{list[j].description}");
                }
            }

            return embedBuilders;
        }

        [Command("buy", RunMode = RunMode.Async)]
        [Summary(" ")]
        public async Task Buy([Remainder]string name)
        {
            Player player = await database.FindPlayer(Context.Message.Author.Id);

            if (player != null)
            { 
                foreach (var category in database.shop)
                {   
                    foreach (var item in category)
                    {    
                        if (name.ToLower() == item.name.ToLower())
                        {
                            if (player.wallet >= item.price)
                            {
                                player.wallet -= item.price;
                                player.items.Add(item);
                                await Context.Channel.SendMessageAsync($"Bought {item.name}. Your wallet: {player.wallet}");
                                return;
                            }
                            else
                            {
                                await Context.Channel.SendMessageAsync($"Lack of funds! Your wallet: {player.wallet}");
                                return;
                            }
                        }
                    }
                }

                await Context.Channel.SendMessageAsync("Item not found!");
            }
            else
            {
                await Context.Channel.SendMessageAsync("Join to the Kipo's tamagotchi club first!");
            }
        }

        [Command("berries", RunMode = RunMode.Async)]
        [Summary("Round, juicy, sweet or sour list of variety of berries ")]
        public async Task Berries()
        {
            foreach(var embed in await MakeEmbeds(database.shop[0], "Berries"))
                await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("drinks", RunMode = RunMode.Async)]
        [Summary("A full list of colourful drinks you can buy")]
        public async Task Drinks()
        {
            foreach (var embed in await MakeEmbeds(database.shop[1], "Drinks"))
                await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("fruits", RunMode = RunMode.Async)]
        [Summary("Many fruits to choose from and fill pets stomach with")]
        public async Task Fruits()
        {
            foreach (var embed in await MakeEmbeds(database.shop[2], "Fruits"))
                await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("meats", RunMode = RunMode.Async)]
        [Summary(" Tasty meat to get for you pets enjoyment")]
        public async Task Meats()
        {
            foreach (var embed in await MakeEmbeds(database.shop[3], "Meats"))
                await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("potions", RunMode = RunMode.Async)]
        [Summary("Brewed in the secret dungeons restores a lot of nice stuff")]
        public async Task Potions()
        {
            foreach (var embed in await MakeEmbeds(database.shop[4], "Potions"))
                await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("tools", RunMode = RunMode.Async)]
        [Summary("Tools for special works")]
        public async Task Tools()
        {
            foreach (var embed in await MakeEmbeds(database.shop[5], "Tools"))
                await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("toys", RunMode = RunMode.Async)]
        [Summary("Check and buy cool toys for your dear pet!")]
        public async Task Toys()
        {
            foreach (var embed in await MakeEmbeds(database.shop[6], "Toys"))
                await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("treats", RunMode = RunMode.Async)]
        [Summary("Treats to fill your pets happiness and hunger!")]
        public async Task Treats()
        {
            foreach (var embed in await MakeEmbeds(database.shop[7], "Treats"))
                await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("vegetables", RunMode = RunMode.Async)]
        [Summary("Fresh grown plants at big fields perfect vegetables for pets ")]
        public async Task Vegetables()
        {
            foreach (var embed in await MakeEmbeds(database.shop[8], "Vegetables"))
                await Context.Channel.SendMessageAsync(embed: embed.Build());
        }
    }
}
