namespace LeGame.Handlers
{
    using System.Collections.Generic;
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
        private static readonly IDictionary<string, ISprite> SharedSprites = new Dictionary<string, ISprite>();
        private static readonly IDictionary<string, ISprite> UniqueSprites = new Dictionary<string, ISprite>();

        private static readonly IDictionary<string, Texture2D> TextureLibrary = new Dictionary<string, Texture2D>();
        private static readonly IList<Effect> Effects = new List<Effect>();

        private static readonly IList<string> FileNames = new List<string>();

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
                    SharedSprites.Add(fileName, MakeEnemySprite(content.Load<Texture2D>(fileName)));
                }

                if (lowerCase.Contains("rotation"))
                {
                    SharedSprites.Add(fileName, MakePlayerSprite(content.Load<Texture2D>(fileName)));
                }

                if (lowerCase.Contains("projectile"))
                {
                    SharedSprites.Add(fileName, MakeRotationSprite(content.Load<Texture2D>(fileName)));
                }

                if (lowerCase.Contains("effect"))
                {
                    SharedSprites.Add(fileName, MakeEffectSprite(content.Load<Texture2D>(fileName)));
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
                GetSprite(enemy).Update(gameTime, enemy);
                enemy.Move();
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
            level.Assets.ForEach(
                asset =>
                    {
                        // Make sure Items are always top layer.
                        if (asset is IPickable)
                        {
                            spriteBatch.Draw(
                                GetTexture(asset),
                                asset.Position,
                                null,
                                null,
                                null,
                                0,
                                null,
                                null,
                                SpriteEffects.None,
                                1); // Layer 1 since everything else is 0
                        }
                        else
                        {
                            spriteBatch.Draw(GetTexture(asset), asset.Position);
                        }
                    });
            spriteBatch.End();

            DrawExistingEffects(spriteBatch);

            UpdateUniqueSprites(level.Enemies);
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
        
        // Get Bounding Box
        public static Rectangle GetBBox(IGameObject obj)
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
            else if (obj.Type.ToLower().Contains("rotation") || obj.Type.ToLower().Contains("projectile"))
            {
                pos = new Vector2(pos.X - GlobalVariables.TileWidth / 2f, pos.Y - GlobalVariables.TileHeight / 2f);
                width = GlobalVariables.TileWidth;
                height = GlobalVariables.TileHeight;
            }

            return new Rectangle((int)(pos.X + 6), (int)(pos.Y + 6), width - 12, height - 10);
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

        // Get GameObject Width
        public static int GetWidth(IGameObject obj)
        {
            return GetBBox(obj).Width;
        }

        // Get GameObject Height
        public static int GetHeight(IGameObject obj)
        {
            return GetBBox(obj).Height;
        }

        private static void UpdateUniqueSprites(ICollection<ICharacter> enemies)
        {
            if (UniqueSprites.Count < enemies.Count)
            {
                // Add the new enemies to the list.
                foreach (ICharacter enemy in enemies.Where(e => !UniqueSprites.ContainsKey(e.Id)))
                {
                    UniqueSprites.Add(enemy.Id, new FourDirectionSprite(GetTexture(enemy.Type)));
                }
            }
            else if (UniqueSprites.Count > enemies.Count)
            {
                // Make sure that the dead enemies are not kept in the list.
                foreach (var sprite in UniqueSprites.Where(s => !enemies.Select(e => e.Id).Contains(s.Key)).ToList())
                {
                    UniqueSprites.Remove(sprite);
                }
            }
        }

        private static void DrawExistingEffects(SpriteBatch spriteBatch)
        {
            foreach (var effect in Effects.ToList())
            {
                effect.Sprite.Draw(spriteBatch, effect.Location);
            }
        }

        private static void UpdateExistingEffects(GameTime gameTime)
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
        private static ISprite GetSprite(IGameObject obj)
        {
            if (UniqueSprites.ContainsKey(obj.Id))
            {
                return UniqueSprites[obj.Id];
            }
            
            return SharedSprites[obj.Type];
        }

        // Get Texture
        private static Texture2D GetTexture(IGameObject obj)
        {
            return TextureLibrary[obj.Type];
        }

        private static Texture2D GetTexture(string type)
        {
            return TextureLibrary[type];
        }

        // Making SharedSprites
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
