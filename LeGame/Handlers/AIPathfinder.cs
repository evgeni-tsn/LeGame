namespace LeGame.Handlers
{
    using Core;

    using Interfaces;

    using LeGame.Enumerations;

    using Microsoft.Xna.Framework;

    using Models.Characters.Enemies;

    using static LeGame.Enumerations.MoveDirection;

    public static class AiPathfinder
    {
        //private const float tolerance = 0.001f;

        public static void FindPath(ICharacter player, ICharacter ai)
        {
            if (ai.CurrentHealth < 0)
            {
                return;
            }

            var enemyAi = (Enemy)ai;

            if ((ai as Enemy).IsAggroed == false)
            {
                Enemy vrag = ai as Enemy;
                Rectangle vragBbox = GfxHandler.GetBBox(vrag);
                Rectangle playerBbox = GfxHandler.GetBBox(player);
                ISpawnLocation spawnLocation = vrag.SpawnLocation;
                Rectangle spawnBbox = spawnLocation.InfalateBBox();
                Rectangle aggroBox = vragBbox;
                aggroBox.Inflate(100, 100);

                if (vrag.Direction == NotSet)
                {
                    // Random initial movement direction.
                    vrag.Direction = (MoveDirection)GlobalVariables.Rng.Next(1, 5);
                }

                if (aggroBox.Intersects(playerBbox))
                {
                    vrag.IsAggroed = true;
                }

                if (vragBbox.Intersects(spawnBbox) && CollisionHandler.Collide(ai, ai.Level.Assets) == null)
                {
                    if (vrag.Direction == Down)
                    {
                        MovementHandler.MoveDown(ai, 0.5f);
                    }
                    else if (vrag.Direction == Up)
                    {
                        MovementHandler.MoveUp(ai, 0.5f);
                    }
                    else if (vrag.Direction == Left)
                    {
                        MovementHandler.MoveLeft(ai, 0.5f);
                    }
                    else if (vrag.Direction == Right)
                    {
                        MovementHandler.MoveRight(ai, 0.5f);
                    }
                }
                else
                {
                    if (vrag.Direction == Down)
                    {
                        MovementHandler.MoveUp(ai, 2f);
                        enemyAi.Direction = Up;
                    }
                    else if (vrag.Direction == Up)
                    {
                        MovementHandler.MoveDown(ai, 2f);
                        enemyAi.Direction = Down;
                    }
                    else if (vrag.Direction == Right)
                    {
                        MovementHandler.MoveLeft(ai, 2f);
                        enemyAi.Direction = Left;
                    }
                    else if (vrag.Direction == Left)
                    {
                        MovementHandler.MoveRight(ai, 2f);
                        enemyAi.Direction = Right;
                    }
                }
                return;
            }

            // Testing out without this

            //if (Math.Abs(ai.Position.X - player.Position.X) > tolerance && 
            //    Math.Abs(ai.Position.Y - player.Position.Y) > tolerance)
            //{
            //    if (GlobalVariables.Rng.Next(1, 3) == 1)
            //    {
            //        if (ai.Position.X < player.Position.X)
            //        {
            //            MovementHandler.MoveRight(ai);
            //            enemyAi.Direction = Right;
            //        }
            //        else if (ai.Position.X > player.Position.X)
            //        {
            //            MovementHandler.MoveLeft(ai);
            //            enemyAi.Direction = Left;
            //        }
            //        //else if(ai.Position.X < player.Position.X +10 || ai.Position.X > player.Position.X-10)
            //        //{
            //            if (ai.Position.Y < player.Position.Y)
            //            {
            //                MovementHandler.MoveDown(ai);
            //                enemyAi.Direction = Down;
            //            }
            //            else if (ai.Position.Y > player.Position.Y)
            //            {
            //                MovementHandler.MoveUp(ai);
            //                enemyAi.Direction = Up;
            //            }
            //       // }
            //    }
            //}
            //else
            //{
                
                if (ai.Position.Y < player.Position.Y)
                {
                    MovementHandler.MoveDown(ai, 0.7f);
                    enemyAi.Direction = Down;
                }
                else if (ai.Position.Y > player.Position.Y)
                {
                    MovementHandler.MoveUp(ai, 0.7f);
                    enemyAi.Direction = Up;
                }

                if (ai.Position.X < player.Position.X)
                {
                    MovementHandler.MoveRight(ai, 0.7f);
                    enemyAi.Direction = Right;
                }
                else if (ai.Position.X > player.Position.X)
                {
                    MovementHandler.MoveLeft(ai, 0.7f);
                    enemyAi.Direction = Left;
                }
            //}
        }
    }
}
