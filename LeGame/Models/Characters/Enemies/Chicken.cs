using LeGame.Interfaces;

namespace LeGame.Models.Characters.Enemies
{
    using Microsoft.Xna.Framework;

    public class Chicken : Enemy
    {
        private const string ChickenDefaultType = "TestObjects/cockSprite";

        private const int ChickenDefaultMaxHealth = 100;

        private const int ChickenDefaultCurrentHealth = 100;

        private const int ChickenDefaultSpeed = 2;

        private const int ChickenDefaultHitCooldown = 50;

        public Chicken(Vector2 position,ISpawnLocation spawnLocation, ILevel level = null)
            : base(position,spawnLocation, ChickenDefaultType, ChickenDefaultMaxHealth, ChickenDefaultCurrentHealth, ChickenDefaultSpeed, ChickenDefaultHitCooldown, level)
        {
        }
    }
}
