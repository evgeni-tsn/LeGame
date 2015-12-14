namespace LeGame.Models.Characters.Player
{
    using Microsoft.Xna.Framework;

    public class Blondy : Player
    {
        private const string BlondyDefaultType = "Player/p1Rotation";

        private const int BlondyDefaultMaxHealth = 200;

        private const int BlondyDefaultCurrentHealth = 100;

        private const int BlondyDefaultSpeed = 2;

        private const int BlondyDefaultHitCooldown = 2000;

        public Blondy(Vector2 position, Level level)
            : base(position, BlondyDefaultType, BlondyDefaultMaxHealth, BlondyDefaultCurrentHealth, BlondyDefaultSpeed, BlondyDefaultHitCooldown, level)
        {
            
        }
    }
}
