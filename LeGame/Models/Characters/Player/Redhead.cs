using LeGame.Interfaces;

namespace LeGame.Models.Characters.Player
{
    using Microsoft.Xna.Framework;

    public class Redhead : Player
    {
        private const string RedheadDefaultType = "Player/p3Rotation";

        private const int RedheadDefaultMaxHealth = 150;

        private const int RedheadDefaultCurrentHealth = 150;

        private const int RedheadDefaultSpeed = 2;

        private const int RedheadDefaultHitCooldown = 2000;

        public Redhead(ILevel level = null)
            : base(RedheadDefaultType, RedheadDefaultMaxHealth, RedheadDefaultCurrentHealth, RedheadDefaultSpeed, RedheadDefaultHitCooldown, level)
        {
        }
    }
}
