using System;
using LeGame.Models.Characters;
using LeGame.Models.Characters.Enemies;
using Microsoft.Xna.Framework;

namespace LeGame.Handlers
{
    public static class AiPathfinder
    {
        public static void FindPath(Character player, Character ai)
        {
            const double tolerance = 0.000001;

            Random rng = new Random();
            if (Math.Abs(ai.Position.X - player.Position.X) > tolerance && 
                Math.Abs(ai.Position.Y - player.Position.Y) > tolerance)
            {
                if (rng.Next(1, 3) == 1)
                {
                    if (ai.Position.X < player.Position.X)
                    {
                        ai.Position = new Vector2(ai.Position.X + ai.Speed, ai.Position.Y);
                        ((SampleEnemy) ai).Direction = "Right";
                    }
                    else if (ai.Position.X > player.Position.X)
                    {
                        ai.Position = new Vector2(ai.Position.X - ai.Speed, ai.Position.Y);
                        ((SampleEnemy) ai).Direction = "Left";
                    }
                    else
                    {
                        if (ai.Position.Y < player.Position.Y)
                        {
                            ai.Position = new Vector2(ai.Position.X, ai.Position.Y + ai.Speed);
                            ((SampleEnemy) ai).Direction = "Down";
                        }
                        else if (ai.Position.Y > player.Position.Y)
                        {
                            ai.Position = new Vector2(ai.Position.X, ai.Position.Y - ai.Speed);
                            ((SampleEnemy) ai).Direction = "Up";
                        }
                    }
                }
            }
            else
            {
                if (ai.Position.X < player.Position.X)
                {
                    ai.Position = new Vector2(ai.Position.X + ai.Speed, ai.Position.Y);
                    ((SampleEnemy) ai).Direction = "Right";
                }
                else if (ai.Position.X > player.Position.X)
                {
                    ai.Position = new Vector2(ai.Position.X - ai.Speed, ai.Position.Y);
                    ((SampleEnemy) ai).Direction = "Left";
                }
                else if (ai.Position.Y < player.Position.Y)
                {
                    ai.Position = new Vector2(ai.Position.X, ai.Position.Y + ai.Speed);
                    ((SampleEnemy) ai).Direction = "Down";
                }
                else if (ai.Position.Y > player.Position.Y)
                {
                    ai.Position = new Vector2(ai.Position.X, ai.Position.Y - ai.Speed);
                    ((SampleEnemy) ai).Direction = "Up";
                }
            }
        }
    }
}
