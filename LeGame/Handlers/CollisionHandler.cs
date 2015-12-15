namespace LeGame.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;
    using Models;
    using Models.Characters.Enemies;
    using Models.Items.Projectiles;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    internal static class CollisionHandler
    {
        public static void PlayerReaction(ICharacter character, Keys key)
        {
            IEnumerable<IGameObject> collisionItems = character.Level.Assets.Concat(character.Level.Enemies).ToList();
            var collider = Collide(character, collisionItems);

            if (!collider.Equals(-1))
            {
                 Vector2 temp = new Vector2(character.Position.X, character.Position.Y);
               
                // movement reactions
                if (collider is ICollidable && !(collider is IKillable))
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
                    character.Level.Assets.Remove(item);
                }
            }
        }

        public static void ProjectileReaction(Projectile projectile, ILevel level)
        {
            IEnumerable<IGameObject> collisionItems = level.Assets.Concat(level.Enemies).ToList();
            var collider = Collide(projectile, collisionItems);

            if (!collider.Equals(-1))
            {
                level.Projectiles.Remove(projectile);

                if (collider is Enemy)
                {
                    var enemy = (Enemy)collider;
                    enemy.TakeDamage(projectile.Attacker);
                }
            }
        }

        public static object Collide(IGameObject collider, IEnumerable<IGameObject> collisionItems)
        {
            foreach (var item in collisionItems)
            {
                Rectangle obj = GfxHandler.GetBBox(item);

                if (((item is ICollidable && ((ICollidable)item).CanCollide) || item is IPickable)
                    && GfxHandler.GetBBox(collider).Intersects(obj))
                {
                    return item;
                }
            }

            return -1;
        }

        public static void AiCollide(IGameObject collider, ICharacter character)
        {
            Rectangle colliderBBox = GfxHandler.GetBBox(collider);
            Rectangle charBBox = GfxHandler.GetBBox(character);
            if (colliderBBox.Intersects(charBBox))
            {
                character.TakeDamage((ICharacter)collider);

                // Console.Beep(3000, 49);
                if (character.CurrentHealth < 0)
                {
                    // guess =)
                }
            }
        }
    }
}
