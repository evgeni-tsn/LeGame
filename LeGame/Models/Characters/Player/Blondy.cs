namespace LeGame.Models.Characters.Player
{
    using LeGame.Interfaces;

    public class Blondy : Player
    {
        private const string BlondyDefaultType = "Player/p1Rotation";

        private const int BlondyDefaultMaxHealth = 200;

        private const int BlondyDefaultCurrentHealth = 100;

        private const int BlondyDefaultSpeed = 3;

        private const int BlondyDefaultHitCooldown = 2000;

        public Blondy(ILevel level = null)
            : base(BlondyDefaultType, BlondyDefaultMaxHealth, BlondyDefaultCurrentHealth, BlondyDefaultSpeed, BlondyDefaultHitCooldown, level)
        {
        }
    }
}
