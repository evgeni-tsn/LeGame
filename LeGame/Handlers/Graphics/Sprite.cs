using LeGame.Interfaces;
using LeGame.Models.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Handlers.Graphics
{
    public abstract class Sprite: ISprite
    {

        protected Sprite(Texture2D texture)
        {
            this.Texture = texture;
            this.Rows = this.Texture.Height / GlobalVariables.TileHeight;
            this.Columns = this.Texture.Width / GlobalVariables.TileWidth;
        }

        public Texture2D Texture { get; }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public virtual void Update(GameTime gameTime, Character character)
        {
        }
    }
}