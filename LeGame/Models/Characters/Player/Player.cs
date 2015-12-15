namespace LeGame.Models.Characters.Player
{
    using System;
    using System.Linq;

    using LeGame.Engine;
    using LeGame.Handlers;
    using LeGame.Interfaces;
    using LeGame.Models.Items.Weapons;

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

        public Keys[] KbKeys { get; } = { Keys.W, Keys.A, Keys.S, Keys.D };

        public override void Move()
        {
            KeyboardState kbState = Keyboard.GetState();
            MouseState mState = Mouse.GetState();

            this.FacingAngle = (float)((Math.PI * 0.5f) + Math.Atan2(mState.Y - this.Position.Y, mState.X - this.Position.X));
            //Console.WriteLine(FacingAngle); // Debug

            foreach (var key in this.KbKeys.Where(key => kbState.IsKeyDown(key)))
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

            if (mState.LeftButton == ButtonState.Pressed)
            {
                this.AttackUsingWeapon();
            }
        }
    }
}
