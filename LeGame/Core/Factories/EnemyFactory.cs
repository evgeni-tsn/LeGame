namespace LeGame.Core.Factories
{
    using System.Collections.Generic;

    using LeGame.Handlers;
    using LeGame.Interfaces;
    using LeGame.Models.Characters.Enemies;
    using LeGame.Models.Levels.LevelAssets;

    using Microsoft.Xna.Framework;

    using static GlobalVariables;

    // Rng

    public static class EnemyFactory
    {
        public static IEnumerable<ICharacter> MakeRandomEnemies(IList<SpawnLocation> locations)
        {
            IList<ICharacter> enemies = new List<ICharacter>();

            foreach (SpawnLocation location in locations)
            {
                Rectangle hugeBox = location.InflateBBox();

                var randomPosition = new Vector2(
                    Rng.Next(hugeBox.Left + 10, hugeBox.Right - 10), 
                    Rng.Next(hugeBox.Top + 10, hugeBox.Bottom - 10));
                ICharacter enemy;

                switch (Rng.Next(0, 3))
                {
                    case 0:
                        enemy = new Zombie(randomPosition, location);
                        break;
                    case 1:
                        enemy = new Crawler(randomPosition, location);
                        break;
                    case 2:

                        // Skip some locations for a bit randomness.
                        continue;
                    default:
                        enemy = new Chicken(randomPosition, location);
                        break;
                }

                enemy.Died += (sender, args) => GfxHandler.AddDeathEffect(sender);
                enemy.Died += (sender, args) => ItemFactory.SpawnPotionByChance(sender);
                enemy.Damaged += (sender, args) => GfxHandler.AddBloodEffect(sender);

                enemies.Add(enemy);
            }

            return enemies;
        }
    }
}