using System;
using System.Collections.Generic;
using System.Linq;
using LeGame.Interfaces;
using LeGame.Models;
using LeGame.Models.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LeGame.Handlers
{
    using LeGame.Models.Characters.Enemies;
    using LeGame.Models.Items.Projectiles;

    internal static class CollisionHandler
    {
        public static void PlayerReaction(Character character, Keys key)
        {
            List<IGameObject> collisionItems = character.Level.Assets.Concat(character.Level.Enemies).ToList();
            var collider = Collide(character, collisionItems);

            if (!collider.Equals(-1))
            {
                 Vector2 temp = new Vector2(character.Position.X, character.Position.Y);
               
                // movement reactions
                if (collider is ICollisionable)
                {
                    if (key == Keys.D)
                    {
                        temp.X -= character.Speed;
                        character.Position = temp;
                    }

                    if (key == Keys.W)
                    {
                        temp.Y += character.Speed;
                        character.Position = temp;
                    }

                    if (key == Keys.S)
                    {
                        temp.Y -= character.Speed;
                        character.Position = temp;
                    }

                    if (key == Keys.A)
                    {
                        temp.X += character.Speed;
                        character.Position = temp;
                    }
                }
            
                if (collider is IPickable)
                {
                    GameObject item = (GameObject)collider;
                    Console.Beep(8000, 50); 

                    // legit cool gold-pickup sound 
                    // the freeze it causes based on the duration is also legit :D
                    character.Level.Assets.Remove(item);
                }
            }
        }

        public static void ProjectileReaction(Projectile projectile, Character character)
        {
            List<IGameObject> collisionItems = character.Level.Assets.Concat(character.Level.Enemies).ToList();
            object collider = Collide(projectile, collisionItems);

            if (!collider.Equals(-1))
            {
                character.Level.Projectiles.Remove(projectile);

                if (collider is Enemy)
                {
                    var enemy = (Enemy)collider;
                    enemy.CurrentHealth -= projectile.Damage;

                    if (enemy.CurrentHealth < 0)
                    {
                        character.Level.Enemies.Remove(enemy);
                    }
                }
            }
        }

        private static object Collide(IGameObject collider, IEnumerable<IGameObject> collisionItems)
        {
            foreach (var item in collisionItems)
            {
                Rectangle obj = GfxHandler.GetBBox(item);

                if (((item is ICollisionable && ((ICollisionable)item).CanCollide) || item is IPickable)
                    && GfxHandler.GetBBox(collider).Intersects(obj))
                {
                    return item;
                }
            }

            return -1;
        }
    }
}
