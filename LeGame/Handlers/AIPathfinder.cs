namespace LeGame.Handlers
{
    using System;

    using Core;
    using Interfaces;
    using Models.Characters.Enemies;

    using Microsoft.Xna.Framework;

    public static class AiPathfinder
    {
        private const float tolerance = 0.001f;

        public static void FindPath(ICharacter player, ICharacter ai)
        {
            if (ai.CurrentHealth < 0)
            {
                return;
            }

            if (Math.Abs(ai.Position.X - player.Position.X) > tolerance && 
                Math.Abs(ai.Position.Y - player.Position.Y) > tolerance)
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
