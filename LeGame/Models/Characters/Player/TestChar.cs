namespace LeGame.Models.Characters.Player
{
    using Microsoft.Xna.Framework;

    public class TestChar : Player
    {
        //private Level level;
        //private AnimatedSprite Sprite;
        
        public TestChar(Vector2 position, string type, int maxHealth, int currentHealth, int speed, Level level)
            : base(position, type, maxHealth, currentHealth, speed, level)
        {
            
        }
    }
}
