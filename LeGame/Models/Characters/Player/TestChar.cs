using Microsoft.Xna.Framework;

namespace LeGame.Models.Characters.Player
{
    public class TestChar : Player
    {
        //private Level level;
        //private AnimatedSprite sprite;
        
        public TestChar(Vector2 position, string type, int maxHealth, int currentHealth, int speed, Level level)
            : base(position, type, maxHealth, currentHealth, speed, level)
        {
            
        }
    }
}
