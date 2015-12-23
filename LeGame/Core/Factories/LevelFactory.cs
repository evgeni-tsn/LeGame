namespace LeGame.Core.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using LeGame.Enumerations;
    using LeGame.Interfaces;
    using LeGame.Models.Levels;
    using LeGame.Models.Levels.LevelAssets;

    using Microsoft.Xna.Framework;

    public static class LevelFactory
    {
        // Get a new random map, which is not the same as the previous map.
        public static Maps GetNewRandomMap(Maps map, ICharacter player)
        {
            while ((map == Maps.Random) || ((player.Level != null) && player.Level.Type.Contains(map.ToString())))
            {
                // 2 in order to skip the starting map
                map = (Maps)GlobalVariables.Rng.Next(2, 6);
            }

            return map;
        }

        public static ILevel MakeLevel(ICharacter player, Maps map = Maps.Random)
        {
            if (!Enum.IsDefined(typeof(Maps), map))
            {
                throw new ArgumentOutOfRangeException(nameof(map));
            }

            // map = GetNewRandomMap(map, player);
            map = GetMapByOrder(player);
            ILevel newLevel = new Level($@"{GlobalVariables.ContentDir}Maps\{map}.txt", player);

            if (map == Maps.HouseMap)
            {
                newLevel.Assets.AddRange(ItemFactory.MakeTestItems());
            }

            var spawnLocations = (from asset in newLevel.Assets
                                  where asset.Type.Contains("SpawnPoint")
                                  select new SpawnLocation(asset.Position, asset.Type, 0, false)).ToList();

            if (map.ToString().Contains("Bloody"))
            {
                IEnumerable<ICharacter> enemies = EnemyFactory.MakeRandomEnemies(spawnLocations);
                newLevel.Enemies.AddRange(enemies);

                // TODO figure a way to avoid hardcoding here
                player.Position = GetNewPlayerPosition(player.Position);
            }

            foreach (ICharacter enemy in newLevel.Enemies)
            {
                enemy.Level = newLevel;
            }

            return newLevel;
        }

        private static Maps GetMapByOrder(ICharacter player)
        {
            Maps returnMap;
            string levelType = player.Level?.Type;

            if (string.IsNullOrEmpty(levelType))
            {
                returnMap = Maps.HouseMap;
            }
            else if (levelType.Contains("HouseMap"))
            {
                returnMap = Maps.BloodyMapN;
            }
            else if (levelType.Contains("BloodyMapN"))
            {
                returnMap = Maps.BloodyMapW;
            }
            else if (levelType.Contains("BloodyMapW"))
            {
                returnMap = Maps.BloodyMapS;
            }
            else if (levelType.Contains("BloodyMapS"))
            {
                returnMap = Maps.BloodyMapE;
            }
            else
            {
                returnMap = Maps.BloodyMapN;
            }

            return returnMap;
        }

        private static Vector2 GetNewPlayerPosition(Vector2 position)
        {
            Vector2 newPlayerPosition = position;

            if (position.X < 100)
            {
                newPlayerPosition = new Vector2(position.X + 540, position.Y);
            }
            else if (position.X > 540)
            {
                newPlayerPosition = new Vector2(position.X - 540, position.Y);
            }
            else if (position.Y < 100)
            {
                newPlayerPosition = new Vector2(position.X, position.Y + 395);
            }
            else if (position.Y > 395)
            {
                newPlayerPosition = new Vector2(position.X, position.Y - 395);
            }

            return newPlayerPosition;
        }
    }
}