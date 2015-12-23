namespace LeGame.Interfaces
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface ISprite
    {
        int Columns { get; set; }

        int Rows { get; set; }

        void Draw(
            SpriteBatch spriteBatch, 
            Vector2 location, 
            float rotationA = 0, 
            float rotationB = 0, 
            Texture2D additionalTexture = null);

        void Update(GameTime gameTime, ICharacter character = null);
    }
}