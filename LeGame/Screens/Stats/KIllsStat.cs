namespace LeGame.Screens.Stats
{
    using LeGame.Interfaces;
    using LeGame.Models.Characters.Player;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class KillsStat : IStat
    {
        private int currentKillCount;

        private int currentKillGoal;

        // public int TotalEnemies { get; }
        public SpriteFont Font { get; set; }

        public void Draw(ICharacter character, SpriteBatch spriteBatch)
        {
            this.currentKillCount = ((Player)character).KillCount;
            this.currentKillGoal = 25;
            string killStat = $"Kills: {this.currentKillCount} / {this.currentKillGoal}";

            spriteBatch.Begin();
            spriteBatch.DrawString(this.Font, killStat, new Vector2(650, 30), Color.Red);

            spriteBatch.End();
        }

        public void Load(ContentManager content)
        {
        }
    }
}