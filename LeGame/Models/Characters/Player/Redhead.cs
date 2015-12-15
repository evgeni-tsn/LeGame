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

        public Redhead(Vector2 position, ILevel level)
            : base(position, RedheadDefaultType, RedheadDefaultMaxHealth, RedheadDefaultCurrentHealth, RedheadDefaultSpeed, RedheadDefaultHitCooldown, level)
        {
            
        }
    }
}
