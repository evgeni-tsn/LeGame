namespace LeGame.Models.Characters.Player
{
    using LeGame.Interfaces;

    public class Blondy : Player
    {
        private const int BlondyDefaultCurrentHealth = 100;

        private const int BlondyDefaultHitCooldown = 2000;

        private const int BlondyDefaultMaxHealth = 200;

        private const int BlondyDefaultSpeed = 3;

        private const string BlondyDefaultType = "Player/p1Rotation";

        public Blondy(ILevel level = null)
            : base(
                BlondyDefaultType, 
                BlondyDefaultMaxHealth, 
                BlondyDefaultCurrentHealth, 
                BlondyDefaultSpeed, 
                BlondyDefaultHitCooldown, 
                level)
        {
        }
    }
}