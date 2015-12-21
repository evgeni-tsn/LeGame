using LeGame.Models.Misc;

namespace LeGame.Core.Factories
{
    using System.Collections.Generic;

    using LeGame.Handlers;
    using LeGame.Interfaces;
    using LeGame.Models.Characters.Enemies;

    using Microsoft.Xna.Framework;

    using static GlobalVariables; // Rng

    public static class EnemyFactory
    {
        public static IEnumerable<ICharacter> MakeRandomEnemies(IList<SpawnLocation> locations)
        {
            IList<ICharacter> enemies = new List<ICharacter>();

            for (int i = 0; i < locations.Count; i++)
            {
                Rectangle hugeBox = locations[i].InfalateBBox();

                for (int j = 0; j <5; j++)
                {
                    var randomPosition = new Vector2(Rng.Next(hugeBox.Left + 10, hugeBox.Right - 10), Rng.Next(hugeBox.Top + 10, hugeBox.Bottom - 10));
                    var enemy = new Chicken(randomPosition, locations[i]);
                    enemy.Died += (sender, args) => GfxHandler.AddDeathEffect(sender);
                    enemy.Died += (sender, args) => ItemFactory.SpawnPotionByChance(sender);
                    enemy.Damaged += (sender, args) => GfxHandler.AddBloodEffect(sender);

                    enemies.Add(enemy);
                }
               
                

                
            }

            return enemies;
        }
    }
}
