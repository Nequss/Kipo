﻿using Discord;
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
using ImageMagick;
using KipoBot.Database;
using KipoBot.Services;
using KipoBot.Utils;

namespace KipoBot.Modules
{
    public class WelcomeModule : ModuleBase<SocketCommandContext>
    {
        Manager manager = new Manager();

        [Command("setwelcome", RunMode = RunMode.Async)]
        public async Task SetWelcome(SocketTextChannel channel_id, int image) => await manager.InsertWelcome(Context.Guild.Id.ToString(), channel_id.Id.ToString(), image);

        [Command("removewelcome", RunMode = RunMode.Async)]
        public async Task RemoveWelcome() => await manager.DeleteWelcome(Context.Guild.Id.ToString());
    }
}