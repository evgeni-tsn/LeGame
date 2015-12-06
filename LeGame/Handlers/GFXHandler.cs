using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LeGame.Models;
using LeGame.Models.LevelAssets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Handlers
{
    public static class GfxHandler
    {
        private static Dictionary<string, Texture2D> lib = new Dictionary<string, Texture2D>();
        private static List<string> fileNames = new List<string>(); 

        public static void Initialise(ContentManager content)
        {
            GetFilenames(GlobalVariables.CONTENT_DIR);
            foreach (string s in fileNames)
            {
                // s is something like: "..\\..\\..\\Content\\TestObjects\\catSprite.png"
                //                                   cut out |------this part-------|
                string file = s.Substring(17, s.LastIndexOf('.') - 17);

                // format it appropriately for the content.Load
                // TestObjects\\catSprite -> TestObjects/catSprite
                file = file.Contains('\\') ? file.Replace('\\', '/') : file;

                lib.Add(file, content.Load<Texture2D>(file));
            }
        }

        // Recursively get the files in Content.
        private static void GetFilenames(string sourceDir)
        {
            foreach (string dir in Directory.GetDirectories(sourceDir))
            {
                if (!dir.Contains("bin") && !dir.Contains("obj") && !dir.Contains("Maps"))
                {
                    foreach (string file in Directory.GetFiles(dir))
                    {
                       fileNames.Add(file);
                    }
                }
                GetFilenames(dir);
            }
        }
        // Get Texture
        public static Texture2D GetTexture(GameObject obj)
        {
            return lib[obj.Type];
        }

        public static Texture2D GetTexture(NonInteractiveBG t)
        {
            return lib[t.Type];
        }
        // Get Bounding Box
        public static Rectangle GetBBox(GameObject obj)
        {
            Texture2D texture = GetTexture(obj);

            return new Rectangle(
                    (int)(obj.Position.X + 3),
                    (int)(obj.Position.Y + 3),
                    (int)(texture.Width - 6),
                    (int)(texture.Height - 5));
        }
        // Get Width
        public static int GetWidth(GameObject obj)
        {
            return GetTexture(obj).Width;
        }

        public static int GetWidth(NonInteractiveBG t)
        {
            return GetTexture(t).Width;
        }
        // Get Height
        public static int GetHeight(GameObject obj)
        {
            return GetTexture(obj).Height;
        }

        public static int GetHeight(NonInteractiveBG t)
        {
            return GetTexture(t).Height;
        }
    }
}
