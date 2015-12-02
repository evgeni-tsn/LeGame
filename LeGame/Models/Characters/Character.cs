using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LeGame.Handlers;

namespace LeGame.Classes.Characters
{
    public abstract class Character : GameObject, IUseWeapon, IKillable, IMovable
    {
        protected Character(Vector2 position, string displayName, int maxHealth, int currentHealth, int speed, Texture2D texture)
            : base(position, displayName)
        {
            this.MaxHealth = maxHealth;
            this.CurrentHealth = currentHealth;
            this.Speed = speed;
            this.Texture = texture;
        }

        public Texture2D Texture { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Speed { get; set; }


        public virtual void Move()
        {
            KeyboardState state = Keyboard.GetState();
            Keys[] keys = { Keys.W, Keys.A, Keys.S, Keys.D };

            foreach (var key in keys)
            {
                if (state.IsKeyDown(key))
                {
                    switch (key)
                    {
                        case Keys.D: MovementHandler.MoveRight(this);
                            break;
                        case Keys.W: MovementHandler.MoveUp(this);
                            break;
                        case Keys.S: MovementHandler.MoveDown(this);
                            break;
                        case Keys.A: MovementHandler.MoveLeft(this);
                            break;
                    }
                }
            }
        }

        public abstract void AttackUsingWeapon();

    }
}
