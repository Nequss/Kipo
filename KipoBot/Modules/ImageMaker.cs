using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ImageMagick;

namespace Kipo.Modules
{
    public class ImageMaker
    {
        
        private static List<MagickImage> banners = new List<MagickImage>();

        ImageMaker()
        {
        }

        public static void addBanner(MagickImage banner)
        {
            banners.Add(banner);
        }

        public static void loadBanners(String path)
        {
            var files = Directory
                .EnumerateFiles(Directory.GetCurrentDirectory() +"/"+ path, "*.*", SearchOption.TopDirectoryOnly).Select(p=>Path.GetFileName(p));
            
            if (files.Count() <= 0)
            {
                Console.WriteLine($"No banners found in: {Directory.GetCurrentDirectory()+"/"+path}\nAdd banners and rerun Kipo.");
                Process.GetCurrentProcess().Kill();
            }
            
            foreach (var file in files)
            { 
                try
                {
                    addBanner(new MagickImage(path+file));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public static Stream createWelcomeBannerWithText(String text, MagickImage background)
        {
            var textOptions = new MagickReadSettings()
            {
                Font = "fonts/font.ttf",
                StrokeWidth = 2,
                FontWeight = FontWeight.Bold,
                FillColor = MagickColors.White,
                StrokeColor = MagickColors.Black,
                TextGravity = Gravity.Center,
                BackgroundColor = MagickColors.Transparent,
                Width = background.Width,
                Height = background.Height
            };
            
            background.Alpha(AlphaOption.Opaque);
            byte[] imageBytes;

            using (var label = new MagickImage($"label:{text}",textOptions))
            {
                background.Composite(label,0,0,CompositeOperator.Over);
                imageBytes = background.ToByteArray();
            }

            return new MemoryStream(imageBytes);
        }

        public static Stream welcomeUser(string username)
        {
            Random r = new Random();
            return createWelcomeBannerWithText($"Hi, {username}!\nWelcome to the server!", banners[r.Next(banners.Count)]);
        }
    }
}
