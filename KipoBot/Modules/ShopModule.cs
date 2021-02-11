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

namespace KipoBot.Modules
{
    [Group("t")]
    [Name("shop")]
    [Summary("Get food, drinks, accesories and other things for your pets and you.")]
    public class ShopModule : ModuleBase<SocketCommandContext>
    {
        private static DatabaseService database;

        public ShopModule(DatabaseService _database)
        {
            database = _database;
        }
    }
}
