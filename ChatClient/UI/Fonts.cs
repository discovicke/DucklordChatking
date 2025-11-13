using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace ChatClient.UI
{
    public static class Fonts
    {

        public static Font extraLightFont;
        public static Font lightFont;
        public static Font mediumFont;
        public static Font regularFont;
        public static Font boldFont;

        static Fonts()
        {
            List<int> chars = new List<int>();

            // Basic ASCII
            for (int i = 32; i <= 126; i++) chars.Add(i);

            // Support for ÅÄÖ etc
            for (int i = 192; i <= 255; i++) chars.Add(i);

            extraLightFont = Raylib.LoadFontEx("Resources/CascadiaCode-ExtraLight.ttf", 20, chars.ToArray(), chars.Count);
            lightFont = Raylib.LoadFontEx("Resources/CascadiaCode-Light.ttf", 20, chars.ToArray(), chars.Count);
            mediumFont = Raylib.LoadFontEx("Resources/CascadiaCode-Medium.ttf", 20, chars.ToArray(), chars.Count);
            regularFont = Raylib.LoadFontEx("Resources/CascadiaCode-Regular.ttf", 20, chars.ToArray(), chars.Count);
            boldFont = Raylib.LoadFontEx("Resources/CascadiaCode-Bold.ttf", 20, chars.ToArray(), chars.Count);

        }

    }
}