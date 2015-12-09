using LeGame.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Handlers;
using LeGame.Interfaces;
using LeGame.Models.Items.Projectiles;
using LeGame.Models.Items.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LeGame.Models.Characters.Player
{
    public class Player : Character
    {
        private Keys[] kbKeys = { Keys.W, Keys.A, Keys.S, Keys.D };


        public Player(Vector2 position, string type, int maxHealth, int currentHealth, int speed, Level level) 
            : base(position, type, maxHealth, currentHealth, speed, level)
        {
            // TODO: Implement weapon pickup and display it on the character.
            this.EquippedWeapon = new LaserGun();
        }

        public float FacingAngle { get; private set; }
        public float MovementAngle { get; private set; }
        public IWeapon EquippedWeapon { get; set; }

        public Keys[] KbKeys
        {
            get { return this.kbKeys; }
        }

        public override void Move()
        {
            KeyboardState kbState = Keyboard.GetState();
            MouseState mState = Mouse.GetState();

            FacingAngle = (float)((Math.PI * 0.5f) + Math.Atan2(mState.Y - this.Position.Y, mState.X - this.Position.X));
            //Console.WriteLine(FacingAngle); // Debug

            foreach (var key in KbKeys.Where(key => kbState.IsKeyDown(key)))
            {
                switch (key)
                {
                    case Keys.D:
                        MovementHandler.MoveRight(this);
                        MovementAngle = 1.55f;
                        break;
                    case Keys.W:
                        MovementHandler.MoveUp(this);
                        MovementAngle = 0f;
                        break;
                    case Keys.S:
                        MovementHandler.MoveDown(this);
                        MovementAngle = 3.15f;
                        break;
                    case Keys.A:
                        MovementHandler.MoveLeft(this);
                        MovementAngle = -1.55f;
                        break;
                }
                CollisionHandler.Reaction(this, key);
            }

            if (mState.LeftButton == ButtonState.Pressed)
            {
                AttackUsingWeapon();
            }
        }

        public override void AttackUsingWeapon()
        {
            if (EquippedWeapon != null)
            {
                this.EquippedWeapon.Attack(this.Level, this);
            }
        }
    }
}
