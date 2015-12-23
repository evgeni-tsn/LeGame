namespace LeGame.Models.Characters.Player
{
    using LeGame.Interfaces;

    public class Redhead : Player
    {
        private const int RedheadDefaultCurrentHealth = 150;

        private const int RedheadDefaultHitCooldown = 2000;

        private const int RedheadDefaultMaxHealth = 150;

        private const int RedheadDefaultSpeed = 2;

        private const string RedheadDefaultType = "Player/p3Rotation";

        public Redhead(ILevel level = null)
            : base(
                RedheadDefaultType, 
                RedheadDefaultMaxHealth, 
                RedheadDefaultCurrentHealth, 
                RedheadDefaultSpeed, 
                RedheadDefaultHitCooldown, 
                level)
        {
        }
    }
}