namespace LeGame.Models.Characters.Player
{
    using Microsoft.Xna.Framework;

    public class TheGuy : Player
    {
        private const string TheGuyDefaultType = "Player/p2Rotation";

        private const int TheGuyDefaultMaxHealth = 400;

        private const int TheGuyDefaultCurrentHealth = 200;

        private const int TheGuyDefaultSpeed = 2;

        private const int TheGuyDefaultHitCooldown = 2000;

        public TheGuy(Vector2 position, Level level = null)
            : base(position, TheGuyDefaultType, TheGuyDefaultMaxHealth, TheGuyDefaultCurrentHealth, TheGuyDefaultSpeed, TheGuyDefaultHitCooldown, level)
        {
            
        }
    }
}
