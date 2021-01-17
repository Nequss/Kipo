using System;
using System.IO;
using ImageMagick;

namespace Kipo.Modules
{
    public class ImageMaker
    {
        public static String[] backgrounds = {"banner1.jpg","banner2.jpg","banner3.jpg"};
        
        ImageMaker()
        {
        }

        public static Stream createBasicBannerWithCaption(String caption)
        {
            byte[] imageBytes;
            var settings = new MagickReadSettings()
            {
                Font = "fonts/font.ttf",
                StrokeColor = MagickColors.White,
                FillColor = MagickColors.White,
                BackgroundColor = MagickColors.Black,
                Width = 512,
                Height = 128,
                TextGravity = Gravity.Center
            };
            
            using (var image = new MagickImage($"caption:{caption}!",settings))
            {
                image.Composite(image,0,0,CompositeOperator.Over);
                image.Format = MagickFormat.Png;
                imageBytes = image.ToByteArray();
            }

            return new MemoryStream(imageBytes);
        }

        public static Stream createBasicWelcomeBanner(String username)
        {
            return createBasicBannerWithCaption($"Hi, {username}!");
        }

        public static Stream createWelcomeBannerWithImage(String usrname, String path)
        {
            byte[] imageBytes;
            var settings = new MagickReadSettings()
            {
                Font = "fonts/font.ttf",
                StrokeColor = MagickColors.White,
                FillColor = MagickColors.White,
                BackgroundColor = MagickColors.Black,
                Width = 512,
                Height = 128,
                TextGravity = Gravity.Center
            };

            Random r = new Random();
            MagickImage banner = new MagickImage($"banners/banner{r.Next(backgrounds.Length+1)}.jpg");

            using (MagickImage image = new MagickImage($"caption:Hi, {usrname}!\nWelcome to the server!",settings))
            {
                image.Composite(image,0,0,CompositeOperator.Over);
                image.Composite(banner,0,0,CompositeOperator.Over);
                image.Format = MagickFormat.Png;
                imageBytes = image.ToByteArray();
            }

            return new MemoryStream(imageBytes); 
        }
    }
