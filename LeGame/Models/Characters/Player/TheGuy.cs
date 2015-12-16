namespace LeGame.Models.Characters.Player
{
    using LeGame.Interfaces;

    public class TheGuy : IPlayer
    {
        private const string TheGuyDefaultType = "Player/p2Rotation";

        private const int TheGuyDefaultMaxHealth = 400;

        private const int TheGuyDefaultCurrentHealth = 200;

        private const int TheGuyDefaultSpeed = 2;

        private const int TheGuyDefaultHitCooldown = 2000;

        public TheGuy(ILevel level = null)
            : base(TheGuyDefaultType, TheGuyDefaultMaxHealth, TheGuyDefaultCurrentHealth, TheGuyDefaultSpeed, TheGuyDefaultHitCooldown, level)
        {
        }
    }
}
