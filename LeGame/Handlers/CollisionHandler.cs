using LeGame.Models.Characters.Player;

namespace LeGame.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Interfaces;

    using LeGame.Core.Factories;
    using LeGame.Enumerations;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    
    using Models.Characters.Enemies;
    using Models.Items.Projectiles;

    internal static class CollisionHandler
    {
        public static void PlayerReaction(ICharacter character, Keys key)
        {
            IEnumerable<IGameObject> collisionItems = character.Level.Assets.Concat(character.Level.Enemies).ToList();

            var collider = Collide(character, collisionItems);

            if (collider != null)
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
                    var item = (IPickable)collider;

                    // legit cool gold-pickup sound 
                    Console.Beep(8000, 50);
                    if ((character as Player).TryToPick(item))
                    {
                        item.PickedUpBy(character);
                    }

                    var healingItem = item as IHeals;
                    healingItem?.HealCharacter(character);
                }
            }


            IGameObject door = character.Level.Assets.Find(a => a.Type.Contains("Door"));
            if (door != null)
            {
                // TODO: do not assume that the door is to the left of the character to offset it.
                Rectangle doorBox = GfxHandler.GetBBox(door);
                doorBox.Offset(-29, 0);

                Rectangle characterBox = GfxHandler.GetBBox(character);

                if (doorBox.Intersects(characterBox))
                {
                    character.Level = LevelFactory.MakeLevel(Maps.BloodyMap, character);
                    GfxHandler.ClearEffects();
                }
            }
        }

        public static void ProjectileReaction(Projectile projectile, ILevel level)
        {
            IEnumerable<IGameObject> collisionItems = level.Assets.Where(a => !(a is IPickable)).Concat(level.Enemies).ToList();
            IGameObject collider = Collide(projectile, collisionItems);

            if (collider != null)
            {
                level.Projectiles.Remove(projectile);

                var enemy = collider as Enemy;
                enemy?.TakeDamage(projectile.Attacker);
            }
        }

        public static IGameObject Collide(IGameObject collider, IEnumerable<IGameObject> collisionItems)
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

            return null;
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
