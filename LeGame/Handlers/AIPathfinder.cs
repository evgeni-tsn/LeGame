using System;
using LeGame.Models.Characters;
using LeGame.Models.Characters.Enemies;
using Microsoft.Xna.Framework;

namespace LeGame.Handlers
{
    using LeGame.Engine;

    public static class AiPathfinder
    {
        public static void FindPath(Character player, Character ai)
        {
            const float Tolerance = 0.001f;

            if (ai.CurrentHealth < 0)
            {
                return;
            }

            if (Math.Abs(ai.Position.X - player.Position.X) > Tolerance && 
                Math.Abs(ai.Position.Y - player.Position.Y) > Tolerance)
            {
                if (GlobalVariables.Rng.Next(1, 3) == 1)
                {
                    if (ai.Position.X < player.Position.X)
                    {
                        ai.Position = new Vector2(ai.Position.X + ai.Speed, ai.Position.Y);
                        ((Enemy)ai).Direction = "Right";
                    }
                    else if (ai.Position.X > player.Position.X)
                    {
                        ai.Position = new Vector2(ai.Position.X - ai.Speed, ai.Position.Y);
                        ((Enemy)ai).Direction = "Left";
                    }
                    else
                    {
                        if (ai.Position.Y < player.Position.Y)
                        {
                            ai.Position = new Vector2(ai.Position.X, ai.Position.Y + ai.Speed);
                            ((Enemy)ai).Direction = "Down";
                        }
                        else if (ai.Position.Y > player.Position.Y)
                        {
                            ai.Position = new Vector2(ai.Position.X, ai.Position.Y - ai.Speed);
                            ((Enemy)ai).Direction = "Up";
                        }
                    }
                }
            }
            else
            {
                if (ai.Position.X < player.Position.X)
                {
                    ai.Position = new Vector2(ai.Position.X + ai.Speed, ai.Position.Y);
                    ((Enemy)ai).Direction = "Right";
                }
                else if (ai.Position.X > player.Position.X)
                {
                    ai.Position = new Vector2(ai.Position.X - ai.Speed, ai.Position.Y);
                    ((Enemy)ai).Direction = "Left";
                }
                else if (ai.Position.Y < player.Position.Y)
                {
                    ai.Position = new Vector2(ai.Position.X, ai.Position.Y + ai.Speed);
                    ((Enemy)ai).Direction = "Down";
                }
                else if (ai.Position.Y > player.Position.Y)
                {
                    ai.Position = new Vector2(ai.Position.X, ai.Position.Y - ai.Speed);
                    ((Enemy)ai).Direction = "Up";
                }
            }
        }
    }
}
