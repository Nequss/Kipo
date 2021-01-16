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
using KipoBot.Services;
using System.Diagnostics;
using System.Threading;
//using SkiaSharp;

namespace Kipo.Modules
{
    [Name("welcome")]
    [Summary("Contains configuration commands for new user event")]
    public class WelcomeModule : ModuleBase<SocketCommandContext>
    {
        /*
        [Command("welcome", RunMode = RunMode.Async)]
        public async Task Welcome1()
        {
            var bitmap = SKBitmap.Decode("welcome1.jpeg");
            var font = SKTypeface.FromFile("Kipo.ttf");
            var canvas = new SKCanvas(bitmap);

            var brush = new SKPaint
            {
                Typeface = font,
                TextSize = 20.0f,
                TextAlign = SKTextAlign.Center,
                IsAntialias = true,
                Color = SKColors.Black
            };

            var coord = new SKPoint(bitmap.Width / 2, bitmap.Height / 2);

            canvas.DrawText("Welcome to the Nyanners!", coord, brush);
            canvas.Flush();

            var image = SKImage.FromBitmap(bitmap);
            var data = image.Encode();

            await Context.Channel.SendFileAsync(data.AsStream(), "Welcome");
            
        }
        */
    }
}
