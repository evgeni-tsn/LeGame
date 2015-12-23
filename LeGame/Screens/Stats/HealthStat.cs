using LeGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Screens.Stats
{
    public class HealthStat : IStat
    {

        private int healthPoints;
        private string healthText;

        private const int PositionX = 650;
        private const int PositionY = 10;

        public Vector2 Position { get; }

        public SpriteFont Font { get; set; }

        public HealthStat()
        {
            this.Position = new Vector2(PositionX, PositionY);
        }

        public void Load(ContentManager content)
        {

           
        }

        public void Draw(ICharacter character, SpriteBatch spriteBatch)
        {
            this.healthPoints = character.CurrentHealth;
            this.healthText = $"Health points: {this.healthPoints}";

            spriteBatch.Begin();
            spriteBatch.DrawString(this.Font, this.healthText, new Vector2(650, 10), Color.Red);
            spriteBatch.End();
        }
    }
}
