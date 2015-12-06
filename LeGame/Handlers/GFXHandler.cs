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
        private static Dictionary<string, AnimatedSprite> Sprites = new Dictionary<string, AnimatedSprite>();
        private static Dictionary<string, Texture2D> textureLibrary = new Dictionary<string, Texture2D>();
        private static List<string> fileNames = new List<string>();

        public static void Load(ContentManager content)
        {
            GetFilenames(GlobalVariables.CONTENT_DIR);
            foreach (string s in fileNames)
            {
                // s is something like: "..\..\..\Content\TestObjects\catSprite.png"
                //                      |->     17     <-|----- take this -----|   |
                string file = s.Substring(17, s.LastIndexOf('.') - 17);

                // format it appropriately for the content.Load
                // TestObjects\catSprite -> TestObjects/catSprite
                file = file.Contains('\\') ? file.Replace('\\', '/') : file;

                if (file.ToLower().Contains("sprite"))
                {
                    Sprites.Add(file, MakeSprite(content.Load<Texture2D>(file)));
                }
                textureLibrary.Add(file, content.Load<Texture2D>(file));
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
        // Make Sprite
        private static AnimatedSprite MakeSprite(Texture2D texture)
        {
            int rows = texture.Height / 32;
            int columns = texture.Width / 32;
            return new AnimatedSprite(texture, rows, columns);
        }
        // Get Sprite
        public static AnimatedSprite GetSprite(GameObject obj)
        {
            return Sprites[obj.Type];
        }
        // Get Texture
        public static Texture2D GetTexture(GameObject obj)
        {
            return textureLibrary[obj.Type];
        }

        public static Texture2D GetTexture(NonInteractiveBG t)
        {
            return textureLibrary[t.Type];
        }
        // Get Bounding Box
        public static Rectangle GetBBox(GameObject obj)
        {
            Texture2D texture = GetTexture(obj);
            Vector2 pos = obj.Position;
            int width = texture.Width;
            int height = texture.Height;

            if (obj.Type.ToLower().Contains("sprite"))
            {
                width = 32;
                height = 32;
            }

            return new Rectangle((int)(pos.X + 3), (int)(pos.Y + 3), width - 6, height - 5);
        }
        // Get Width
        public static int GetWidth(GameObject obj)
        {
            return GetBBox(obj).Width;
        }

        public static int GetWidth(NonInteractiveBG t)
        {
            return GetTexture(t).Width;
        }
        // Get Height
        public static int GetHeight(GameObject obj)
        {
            return GetBBox(obj).Height;
        }

        public static int GetHeight(NonInteractiveBG t)
        {
            return GetTexture(t).Height;
        }
    }
}
