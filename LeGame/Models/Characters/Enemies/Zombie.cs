namespace LeGame.Models.Characters.Enemies
{
    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;

    public class Zombie : Enemy
    {
        private const int ZombieCurrentHealth = 150;

        private const int ZombieHitCooldown = 50;

        private const int ZombieMaxHealth = 200;

        private const int ZombieSpeed = 2;

        private const string ZombieType = "Enemies/ZombieSprite";

        public Zombie(Vector2 position, ISpawnLocation spawnLocation, ILevel level = null)
            : base(
                position, 
                spawnLocation, 
                ZombieType, 
                ZombieMaxHealth, 
                ZombieCurrentHealth, 
                ZombieSpeed, 
                ZombieHitCooldown, 
                level)
        {
        }
    }
}