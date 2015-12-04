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
        public Player(Vector2 position, string displayName, int maxHealth, int currentHealth, int speed, Texture2D texture, Level level) 
            : base(position, displayName, maxHealth, currentHealth, speed, texture, level)
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
                }
            }
        }

        public override void AttackUsingWeapon()
        {
            throw new NotImplementedException();
        }
    }
}
