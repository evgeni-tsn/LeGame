
namespace LeGame.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface ISprite
    {
        int Rows { get; set; }

        int Columns { get; set; }

        void Update(GameTime gameTime, ICharacter character = null);

        void Draw(SpriteBatch spriteBatch, Vector2 location, float rotationA = 0, float rotationB = 0, Texture2D additionalTexture = null);
    }
}