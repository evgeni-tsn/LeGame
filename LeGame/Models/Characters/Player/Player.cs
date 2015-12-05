using LeGame.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Handlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LeGame.Models.Characters.Player
{
    public class Player : Character
    {
        public Player(Vector2 position, string type, int maxHealth, int currentHealth, int speed, Level level, Texture2D texture) 
            : base(position, type, maxHealth, currentHealth, speed, level, texture)
        {
        }

        public override void Move()
        {
            KeyboardState state = Keyboard.GetState();
            Keys[] keys = { Keys.W, Keys.A, Keys.S, Keys.D };

            foreach (var key in keys)
            {
                if (state.IsKeyDown(key))
                {
                    switch (key)
                    {
                        case Keys.D:
                            MovementHandler.MoveRight(this);
                            break;
                        case Keys.W:
                            MovementHandler.MoveUp(this);
                            break;
                        case Keys.S:
                            MovementHandler.MoveDown(this);
                            break;
                        case Keys.A:
                            MovementHandler.MoveLeft(this);
                            break;
                    }
                    CollisionHandler.Reaction(this, key);
                    
                }
            }
        }

        public override void AttackUsingWeapon()
        {
            throw new NotImplementedException();
        }
    }
}
