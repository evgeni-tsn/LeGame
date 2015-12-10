using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private static readonly Dictionary<string, AnimatedSprite> Sprites = new Dictionary<string, AnimatedSprite>();
        private static readonly Dictionary<string, RotationSprite> RSprites = new Dictionary<string, RotationSprite>();
        private static readonly Dictionary<string, Texture2D> TextureLibrary = new Dictionary<string, Texture2D>();
        private static readonly List<string> FileNames = new List<string>();

        public static void Load(ContentManager content)
        {
            GetFilenames(GlobalVariables.ContentDir);
            foreach (string s in FileNames)
            {
                // s is something like: "..\..\..\Content\TestObjects\catSprite.png"
                //                      |->     17     <-|>---- take this ----<|   |
                string file = s.Substring(17, s.LastIndexOf('.') - 17);

                // format it appropriately for the content.Load
                // TestObjects\catSprite -> TestObjects/catSprite
                file = file.Contains('\\') ? file.Replace('\\', '/') : file;

                if (file.ToLower().Contains("sprite"))
                {
                    Sprites.Add(file, MakeSprite(content.Load<Texture2D>(file)));
                }
                if (file.ToLower().Contains("rotation") || file.ToLower().Contains("projectile"))
                {
                    RSprites.Add(file, MakeRotationSprite(content.Load<Texture2D>(file)));
                }
                TextureLibrary.Add(file, content.Load<Texture2D>(file));
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
                        FileNames.Add(file);
                    }
                }
                GetFilenames(dir);
            }
        }
        // Get Rotation Sprite 
        public static RotationSprite GetRotationSprite(GameObject obj)
        {
            return RSprites[obj.Type];
        }
        // Get Sprite
        public static AnimatedSprite GetSprite(GameObject obj)
        {
            return Sprites[obj.Type];
        }
        // Get Texture
        public static Texture2D GetTexture(GameObject obj)
        {
            return TextureLibrary[obj.Type];
        }

        public static Texture2D GetTexture(NonInteractiveBg t)
        {
            return TextureLibrary[t.Type];
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
                width = GlobalVariables.TileWidth;
                height = GlobalVariables.TileHeight;
            }
            else if (obj.Type.ToLower().Contains("rotation"))
            {
                pos = new Vector2(pos.X - GlobalVariables.TileWidth / 2f, pos.Y - GlobalVariables.TileHeight / 2f);
                width = GlobalVariables.TileWidth;
                height = GlobalVariables.TileHeight;
            }

            return new Rectangle((int)(pos.X + 3), (int)(pos.Y + 3), width - 6, height - 5);
        }
        // Get Width
        public static int GetWidth(GameObject obj)
        {
            return GetBBox(obj).Width;
        }

        public static int GetWidth(NonInteractiveBg t)
        {
            return GetTexture(t).Width;
        }
        // Get Height
        public static int GetHeight(GameObject obj)
        {
            return GetBBox(obj).Height;
        }

        public static int GetHeight(NonInteractiveBg t)
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
