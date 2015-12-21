using System.Net;
using Microsoft.Xna.Framework.Input.Touch;

namespace LeGame.Handlers
{
    using System;

    using Core;

    using Interfaces;

    using Microsoft.Xna.Framework;

    using Models.Characters.Enemies;

    public static class AiPathfinder
    {
        private const float tolerance = 0.001f;

        public static void FindPath(ICharacter player, ICharacter ai)
        {
            if (ai.CurrentHealth < 0)
            {
                return;
            }
            if ((ai as Enemy).IsAggroed == false)
            {
                Enemy vrag = ai as Enemy;
                Rectangle vragBbox = GfxHandler.GetBBox(vrag);
                Rectangle playerBbox = GfxHandler.GetBBox(player);
                ISpawnLocation spawnLocation = vrag.SpawnLocation;
                Rectangle spawnBbox = spawnLocation.InfalateBBox();
                Rectangle inflatedBox = vragBbox;
                inflatedBox.Inflate(150, 150);
                if (String.IsNullOrEmpty(vrag.Direction))
                {
                    vrag.Direction = "Down";
                }

                if (inflatedBox.Intersects(playerBbox))
                {
                    vrag.IsAggroed = true;
                }
                if (vragBbox.Intersects(spawnBbox))
                {
                    if (vrag.Direction == "Down")
                    {
                        ai.Position = new Vector2(ai.Position.X, ai.Position.Y + ai.Speed/2);
                        //((Enemy)ai).Direction = "Down";
                    }
                    else if (vrag.Direction == "Up")
                    {
                        ai.Position = new Vector2(ai.Position.X, ai.Position.Y - ai.Speed/2);
                        //((Enemy)ai).Direction = "Up";
                    }
                }
                else
                {
                    if (vrag.Direction == "Down")
                    {
                        ai.Position = new Vector2(ai.Position.X, ai.Position.Y - ai.Speed*2);
                        
                        ((Enemy)ai).Direction = "Up";
                    }
                    else if (vrag.Direction == "Up")
                    {
                        ai.Position = new Vector2(ai.Position.X, ai.Position.Y + ai.Speed*2);
                        ((Enemy)ai).Direction = "Down";

                    }
                }
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
                    //else if(ai.Position.X < player.Position.X +10 || ai.Position.X > player.Position.X-10)
                    //{
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
                   // }
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
