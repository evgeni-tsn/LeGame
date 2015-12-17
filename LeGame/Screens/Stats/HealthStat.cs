using System;
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
        private SpriteFont font;
        private const int positionX = 650;
        private const int positionY = 10;
        private Vector2 position;


        public HealthStat()
        {
            this.position = new Vector2(positionX, positionY);
        }

        public void Load(ContentManager content)
        {
            this.font = content.Load<SpriteFont>(@"Fonts/SpriteFont");
        }

        public void Draw(ICharacter character, SpriteBatch spriteBatch)
        {
            healthPoints = character.CurrentHealth;
            healthText = $"Health points: {healthPoints}";

            spriteBatch.Begin();
            spriteBatch.DrawString(this.font, healthText, new Vector2(650, 10), Color.Red);
            spriteBatch.End();
        }
    }
}
