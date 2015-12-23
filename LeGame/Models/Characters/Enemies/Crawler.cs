namespace LeGame.Models.Characters.Enemies
{
    using LeGame.Interfaces;

    using Microsoft.Xna.Framework;

    public class Crawler : Enemy
    {
        private const int CrawlerCurrentHealth = 200;

        private const int CrawlerHitCooldown = 100;

        private const int CrawlerMaxHealth = 200;

        private const int CrawlerSpeed = 1;

        private const string CrawlerType = "Enemies/CrawlerSprite";

        public Crawler(Vector2 position, ISpawnLocation spawnLocation, ILevel level = null)
            : base(
                position, 
                spawnLocation, 
                CrawlerType, 
                CrawlerMaxHealth, 
                CrawlerCurrentHealth, 
                CrawlerSpeed, 
                CrawlerHitCooldown, 
                level)
        {
        }
    }
}