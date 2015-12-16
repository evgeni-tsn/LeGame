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
        public static IEnumerable<ICharacter> MakeRandomEnemies()
        {
            IList<ICharacter> enemies = new List<ICharacter>();

            for (int i = 0; i < Rng.Next(5, 14); i++)
            {
                var randomPosition = new Vector2(Rng.Next(50, WindowWidthDefault - 50), Rng.Next(50, WindowHeightDefault - 250));
                var enemy = new Chicken(randomPosition);

                enemy.Died += (sender, args) => GfxHandler.AddDeathEffect(sender);
                enemy.Damaged += (sender, args) => GfxHandler.AddBloodEffect(sender);

                enemies.Add(enemy);
            }

            return enemies;
        }
    }
}
