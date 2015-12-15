using System.Diagnostics;

namespace LeGame.Models.Characters.Player
{
    using System;
    using System.Linq;

    using Core;
    using Handlers;
    using Interfaces;
    using Items.Weapons;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class Player : Character
    {
        protected Player(Vector2 position, string type, int maxHealth, int currentHealth, int speed, int hitCooldown, ILevel level) 
            : base(position, type, maxHealth, currentHealth, speed, hitCooldown, level)
        {
            // TODO: Implement weapon pickup and display it on the character.
            this.EquippedWeapon = new Unarmed();
        }


        public float FacingAngle { get; private set; }
        public float MovementAngle { get; private set; } 

        private IWeapon EquippedWeapon { get; set; }


        public Keys[] KbKeys { get; } = { Keys.W, Keys.A, Keys.S, Keys.D };

        public override void Move()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            this.FacingAngle = (float)((Math.PI * 0.5f) + Math.Atan2(mouseState.Y - this.Position.Y, mouseState.X - this.Position.X));
            //Console.WriteLine(FacingAngle); //Debug
            //Better use Debug class.
            Debug.WriteLine(this.FacingAngle);

            KeyboardAction(keyboardState);

            MouseAction(mouseState);
        }

        private void KeyboardAction(KeyboardState kbState)
        {
            foreach (var key in this.KbKeys.Where(kbState.IsKeyDown))
            {
                switch (key)
                {
                    case Keys.D:
                        MovementHandler.MoveRight(this);
                        this.MovementAngle = GlobalVariables.RightAngle;
                        break;
                    case Keys.W:
                        MovementHandler.MoveUp(this);
                        this.MovementAngle = GlobalVariables.UpAngle;
                        break;
                    case Keys.S:
                        MovementHandler.MoveDown(this);
                        this.MovementAngle = GlobalVariables.DownAngle;
                        break;
                    case Keys.A:
                        MovementHandler.MoveLeft(this);
                        this.MovementAngle = GlobalVariables.LeftAngle;
                        break;
                }
                CollisionHandler.PlayerReaction(this, key);
            }
        }

        private void MouseAction(MouseState mState)
        {
            if (mState.LeftButton == ButtonState.Pressed)
            {
                AttackUsingWeapon();
            }
        }
    }
}
