namespace LeGame.Screens.Stats
{
    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class HealthStat : IStat
    {
        private const int PositionX = 650;

        private const int PositionY = 10;

        private int healthPoints;

        private string healthText;

        public HealthStat()
        {
            this.Position = new Vector2(PositionX, PositionY);
        }

        public SpriteFont Font { get; set; }

        public Vector2 Position { get; }

        public void Draw(ICharacter character, SpriteBatch spriteBatch)
        {
            this.healthPoints = character.CurrentHealth;
            this.healthText = $"Health points: {this.healthPoints}";

            spriteBatch.Begin();
            spriteBatch.DrawString(this.Font, this.healthText, new Vector2(650, 10), Color.Red);
            spriteBatch.End();
        }

        public void Load(ContentManager content)
        {
        }
    }
}