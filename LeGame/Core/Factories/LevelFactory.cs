using Microsoft.Xna.Framework;

namespace LeGame.Core.Factories
{
    using System.Collections.Generic;

    using LeGame.Enumerations;
    using LeGame.Interfaces;
    using LeGame.Models;

    public static class LevelFactory
    {
        public static ILevel MakeLevel(Maps map, ICharacter player)
        {
            ILevel newLevel = new Level($@"{GlobalVariables.ContentDir}Maps\{map}.txt", player);

            if (map == Maps.BloodyMap)
            {
                IEnumerable<ICharacter> enemies = EnemyFactory.MakeRandomEnemies();
                newLevel.Enemies.AddRange(enemies);
                //TODO figure a way to avoid hardcoding here
                player.Position = new Vector2(600,240);
            }

            foreach (ICharacter enemy in newLevel.Enemies)
            {
                enemy.Level = newLevel;
            }

            newLevel.Assets.AddRange(ItemFactory.MakeTextItems());
            

            return newLevel;
        }
    }
}
