using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LeGame.Handlers.Graphics;
using LeGame.Models;
using LeGame.Models.LevelAssets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Handlers
{
    public static class GfxHandler
    {
        private static Dictionary<string, AnimatedSprite> sprites = new Dictionary<string, AnimatedSprite>();
        private static Dictionary<string, RotationSprite> rSprites = new Dictionary<string, RotationSprite>();
        private static Dictionary<string, Texture2D> textureLibrary = new Dictionary<string, Texture2D>();
        private static List<string> fileNames = new List<string>();

        public static void Load(ContentManager content)
        {
            GetFilenames(GlobalVariables.CONTENT_DIR);
            foreach (string s in fileNames)
            {
                // s is something like: "..\..\..\Content\TestObjects\catSprite.png"
                //                      |->     17     <-|>---- take this ----<|   |
                string file = s.Substring(17, s.LastIndexOf('.') - 17);

                // format it appropriately for the content.Load
                // TestObjects\catSprite -> TestObjects/catSprite
                file = file.Contains('\\') ? file.Replace('\\', '/') : file;

                if (file.ToLower().Contains("sprite"))
                {
                    sprites.Add(file, MakeSprite(content.Load<Texture2D>(file)));
                }
                if (file.ToLower().Contains("rotation"))
                {
                    rSprites.Add(file, MakeRotationSprite(content.Load<Texture2D>(file)));
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
        // Get Rotation Sprite 
        public static RotationSprite GetRotationSprite(GameObject obj)
        {
            return rSprites[obj.Type];
        }
        // Get Sprite
        public static AnimatedSprite GetSprite(GameObject obj)
        {
            return sprites[obj.Type];
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
                width = GlobalVariables.TILE_WIDTH;
                height = GlobalVariables.TILE_HEIGHT;
            }
            else if (obj.Type.ToLower().Contains("rotation"))
            {
                pos = new Vector2(pos.X - GlobalVariables.TILE_WIDTH / 2f, pos.Y - GlobalVariables.TILE_HEIGHT / 2f);
                width = GlobalVariables.TILE_WIDTH;
                height = GlobalVariables.TILE_HEIGHT;
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

        // Make Rotation Sprite
        private static RotationSprite MakeRotationSprite(Texture2D texture)
        {
            return new RotationSprite(texture);
        }
        // Make Sprite
        private static AnimatedSprite MakeSprite(Texture2D texture)
        {
            return new AnimatedSprite(texture);
        }
    }
}
