using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Models.Characters;
using LeGame.Models.Characters.Enemies;
using Microsoft.Xna.Framework;
namespace LeGame.Handlers
{
    public static class AIPathfinder
    {
        public static void FindPath(Character player, Character ai)
        {
            Random rng = new Random();
            if (ai.Position.X != player.Position.X && ai.Position.Y != player.Position.Y)
            {
                if (rng.Next(1, 3) == 1)
                {
                    if (ai.Position.X < player.Position.X)
                    {
                        ai.Position = new Vector2(ai.Position.X + ai.Speed, ai.Position.Y);
                        (ai as SampleEnemy).Direction = "Right";
                    }
                    else if (ai.Position.X > player.Position.X)
                    {
                        ai.Position = new Vector2(ai.Position.X - ai.Speed, ai.Position.Y);
                        (ai as SampleEnemy).Direction = "Left";
                    }
                    else
                    {
                        if (ai.Position.Y < player.Position.Y)
                        {
                            ai.Position = new Vector2(ai.Position.X, ai.Position.Y + ai.Speed);
                            (ai as SampleEnemy).Direction = "Down";
                        }
                        else if (ai.Position.Y > player.Position.Y)
                        {
                            ai.Position = new Vector2(ai.Position.X, ai.Position.Y - ai.Speed);
                            (ai as SampleEnemy).Direction = "Up";
                        }
                    }
                }
            }
            else
            {
                if (ai.Position.X < player.Position.X)
                {
                    ai.Position = new Vector2(ai.Position.X + ai.Speed, ai.Position.Y);
                    (ai as SampleEnemy).Direction = "Right";
                }
                else if (ai.Position.X > player.Position.X)
                {
                    ai.Position = new Vector2(ai.Position.X - ai.Speed, ai.Position.Y);
                    (ai as SampleEnemy).Direction = "Left";
                }
                else if (ai.Position.Y < player.Position.Y)
                {
                    ai.Position = new Vector2(ai.Position.X, ai.Position.Y + ai.Speed);
                    (ai as SampleEnemy).Direction = "Down";
                }
                else if (ai.Position.Y > player.Position.Y)
                {
                    ai.Position = new Vector2(ai.Position.X, ai.Position.Y - ai.Speed);
                    (ai as SampleEnemy).Direction = "Up";
                }
            }
        }
    }
}
