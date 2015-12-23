namespace LeGame.Models.Characters.Enemies
{
    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;

    public class Chicken : Enemy
    {
        private const int ChickenDefaultCurrentHealth = 100;

        private const int ChickenDefaultHitCooldown = 50;

        private const int ChickenDefaultMaxHealth = 100;

        private const int ChickenDefaultSpeed = 2;

        private const string ChickenDefaultType = "TestObjects/cockSprite";

        public Chicken(Vector2 position, ISpawnLocation spawnLocation, ILevel level = null)
            : base(
                position, 
                spawnLocation, 
                ChickenDefaultType, 
                ChickenDefaultMaxHealth, 
                ChickenDefaultCurrentHealth, 
                ChickenDefaultSpeed, 
                ChickenDefaultHitCooldown, 
                level)
        {
        }
    }
}