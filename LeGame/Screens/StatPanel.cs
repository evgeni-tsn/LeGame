namespace LeGame.Screens
{
    using LeGame.Core;
    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class StatPanel
    {
        private SpriteFont font;

        public void DrawHealth(ICharacter character, ContentManager content, SpriteBatch spriteBatch)
        {
            int hp = character.CurrentHealth;
            this.font = content.Load<SpriteFont>(@"Fonts/SpriteFont");
            string healthBar = $"Health points: {hp}";

            spriteBatch.Begin();
            spriteBatch.DrawString(this.font, healthBar, new Vector2(650, 10), Color.Red);
            spriteBatch.End();
        }

        public void EndScreen(ContentManager content, SpriteBatch spriteBatch)
        {
            this.font = content.Load<SpriteFont>(@"Fonts/DeathFont");
            var middle = new Vector2
                (GlobalVariables.WindowWidthDefault / 2f,
                GlobalVariables.WindowHeightDefault / 2f);

            spriteBatch.Begin();
            spriteBatch.DrawString(this.font, "GG NOOB", middle, Color.Red);
            spriteBatch.End();
        }

        internal void Update(MouseState mouse)
        {
        }
    }
}

