namespace LeGame.Handlers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Core;
    using Graphics;
    using Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using Effect = Graphics.Effect;

    public static class GfxHandler
    {
        private static readonly IDictionary<string, ISprite> Sprites = new Dictionary<string, ISprite>(); 
        private static readonly IDictionary<string, Texture2D> TextureLibrary = new Dictionary<string, Texture2D>();
        private static readonly IList<Effect> Effects = new List<Effect>();

        private static readonly IList<string> FileNames = new List<string>();

        private static readonly string[] FoldersToAvoid = { "bin", "obj", "Maps", "Font" };

        public static void Load(ContentManager content)
        {
            FileHandler.GetFilenames(GlobalVariables.ContentDir, FileNames);
            foreach (string s in FileNames)
            {
                // s is something like: "..\..\..\Content\TestObjects\catSprite.png"
                //                      |->     17     <-|>---- take this ----<|   |
                string fileName = s.Substring(17, s.LastIndexOf('.') - 17);

                // format it appropriately for the content.Load
                // TestObjects\catSprite -> TestObjects/catSprite
                fileName = fileName.Contains('\\') ? fileName.Replace('\\', '/') : fileName;

                string lowerCase = fileName.ToLower();
                if (lowerCase.Contains("sprite"))
                {
                    Sprites.Add(fileName, MakeEnemySprite(content.Load<Texture2D>(fileName)));
                }

                if (lowerCase.Contains("rotation"))
                {
                    Sprites.Add(fileName, MakePlayerSprite(content.Load<Texture2D>(fileName)));
                }

                if (lowerCase.Contains("projectile"))
                {
                    Sprites.Add(fileName, MakeRotationSprite(content.Load<Texture2D>(fileName)));
                }

                if (lowerCase.Contains("effect"))
                {
                    Sprites.Add(fileName, MakeEffectSprite(content.Load<Texture2D>(fileName)));
                }
                
                TextureLibrary.Add(fileName, content.Load<Texture2D>(fileName));
            }
        }

        public static void UpdateLevel(GameTime gameTime, ILevel level)
        {
            level.Player.Move();
            GetSprite(level.Player).Update(gameTime, level.Player);
            foreach (var enemy in level.Enemies.ToList())
            {
                enemy.Move();
                GetSprite(enemy).Update(gameTime, enemy);
            }

            foreach (var projectile in level.Projectiles.ToList())
            {
                projectile.Move();
                GetSprite(projectile).Update(gameTime);
            }

            UpdateExistingEffects(gameTime);
        }

        public static void DrawLevel(SpriteBatch spriteBatch, ILevel level)
        {
            spriteBatch.Begin();
            level.Assets.ForEach(t => spriteBatch.Draw(GetTexture(t), t.Position));
            spriteBatch.End();

            DrawExistingEffects(spriteBatch);

            foreach (var ememy in level.Enemies)
            {
                GetSprite(ememy).Draw(spriteBatch, ememy.Position);
            }

            foreach (var projectile in level.Projectiles.ToList())
            {
                GetSprite(projectile).Draw(spriteBatch, projectile.Position, projectile.Angle);

                if (projectile.Lifetime > projectile.Range)
                {
                    level.Projectiles.Remove(projectile);
                }
            }

            GetSprite(level.Player).Draw(spriteBatch, level.Player.Position, level.Player.FacingAngle, level.Player.MovementAngle);
        }

        public static void AddBloodEffect(object sender)
        {
            var bleeder = (IGameObject)sender;
            var position = new Vector2(bleeder.Position.X + 16, bleeder.Position.Y + 16);
            
            Effects.Add(new Effect(new EffectSprite(GetTexture("Effects/BloodEffect"), true), position));
        }

        public static void AddDeathEffect(object sender)
        {
            var riper = (IGameObject)sender;
            var position = new Vector2(riper.Position.X + 16, riper.Position.Y + 16);

            Effects.Add(new Effect(new EffectSprite(GetTexture("Effects/FleshExplosionEffect"), true), position));
        }

        public static void DrawExistingEffects(SpriteBatch spriteBatch)
        {
            foreach (var effect in Effects.ToList())
            {
                effect.Sprite.Draw(spriteBatch, effect.Location);
            }
        }

        public static void UpdateExistingEffects(GameTime gameTime)
        {
            foreach (var effect in Effects.ToList())
            {
                effect.Sprite.Update(gameTime);

                var sprite = (EffectSprite)effect.Sprite;

                if (sprite.HasEnded && !sprite.IsPersistant)
                {
                    Effects.Remove(effect);
                }
            }
        }

        // Get Sprite
        public static ISprite GetSprite(IGameObject obj)
        {
            return Sprites[obj.Type];
        }

        public static ISprite GetSprite(string type)
        {
            return Sprites[type];
        }

        // Get Texture
        public static Texture2D GetTexture(IGameObject obj)
        {
            return TextureLibrary[obj.Type];
        }

        public static Texture2D GetTexture(string type)
        {
            return TextureLibrary[type];
        }

        // Get Bounding Box
        public static Rectangle GetBBox(IGameObject obj)
        {
            var texture = GetTexture(obj);
            Vector2 pos = obj.Position;
            int width = texture.Width;
            int height = texture.Height;

            if (obj.Type.ToLower().Contains("sprite"))
            {
                width = GlobalVariables.TileWidth;
                height = GlobalVariables.TileHeight;
            }
            else if (obj.Type.ToLower().Contains("rotation") || obj.Type.ToLower().Contains("projectile"))
            {
                pos = new Vector2(pos.X - GlobalVariables.TileWidth / 2f, pos.Y - GlobalVariables.TileHeight / 2f);     
                width = GlobalVariables.TileWidth;
                height = GlobalVariables.TileHeight;
            }

            return new Rectangle((int)(pos.X + 6), (int)(pos.Y + 6), width - 12, height - 10);
        }

        // Get Width
        public static int GetWidth(IGameObject obj)
        {
            return GetBBox(obj).Width;
        }

        // Get Height
        public static int GetHeight(IGameObject obj)
        {
            return GetBBox(obj).Height;
        }

        // Making Sprites
        private static EffectSprite MakeEffectSprite(Texture2D texture, bool isPersistant = false)
        {
            return new EffectSprite(texture, isPersistant);
        }

        private static RotationSprite MakeRotationSprite(Texture2D texture)
        {
            return new RotationSprite(texture);
        }
        
        private static PlayerRotationSprite MakePlayerSprite(Texture2D texture)
        {
            return new PlayerRotationSprite(texture);
        }
        
        private static FourDirectionSprite MakeEnemySprite(Texture2D texture)
        {
            return new FourDirectionSprite(texture);
        }
    }
}
