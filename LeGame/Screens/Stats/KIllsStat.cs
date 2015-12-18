using System;

using LeGame.Interfaces;
using LeGame.Models.Characters.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Screens.Stats
{
    public class KillsStat : IStat
    {
        private int totalEnemies;
        private int currentKillCount;
        private int currentKillGoal;
        public SpriteFont Font { get; set; }

        public void Load(ContentManager content)
        {
            
        }

        public void Draw(ICharacter character, SpriteBatch spriteBatch)
        {
            currentKillCount = (character as Player).KillCount;
            currentKillGoal = 25;
            string killStat = string.Format("Kills: {0} / {1}", currentKillCount, currentKillGoal);

            spriteBatch.Begin();
            spriteBatch.DrawString(this.Font,killStat, new Vector2(650, 30), Color.Red);
      
            spriteBatch.End();
        }
    }
}
