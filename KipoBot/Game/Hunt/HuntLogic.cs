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
using System.Reflection;

namespace KipoBot.Game.Hunt
{
    public class HuntLogic
    {
        private readonly InteractiveService interaction;

        public HuntLogic(InteractiveService _interaction)
        {
            interaction = _interaction;
        }

        public async Task<Pet> ChooseEnemy()
        {
            var items = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Namespace == "KipoBot.Game.Hunt.Enemies")
                .ToList();

            return (Pet)Activator.CreateInstance(items[new Random().Next(items.Count - 1)]);
        }

        public async Task Attack()
        {

        }
    }
}
