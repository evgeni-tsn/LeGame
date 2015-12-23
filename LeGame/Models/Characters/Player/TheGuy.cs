namespace LeGame.Models.Characters.Player
{
    using LeGame.Interfaces;

    public class TheGuy : Player
    {
        private const int TheGuyDefaultCurrentHealth = 200;

        private const int TheGuyDefaultHitCooldown = 2000;

        private const int TheGuyDefaultMaxHealth = 400;

        private const int TheGuyDefaultSpeed = 2;

        private const string TheGuyDefaultType = "Player/p2Rotation";

        public TheGuy(ILevel level = null)
            : base(
                TheGuyDefaultType, 
                TheGuyDefaultMaxHealth, 
                TheGuyDefaultCurrentHealth, 
                TheGuyDefaultSpeed, 
                TheGuyDefaultHitCooldown, 
                level)
        {
        }
    }
}