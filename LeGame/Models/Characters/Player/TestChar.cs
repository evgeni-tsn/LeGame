using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Models.Characters.Player
{
    public class TestChar : Player
    {
        public TestChar(Vector2 position, string displayName, int maxHealth, int currentHealth, int speed, Texture2D texture)
            : base(position, displayName, maxHealth, currentHealth, speed, texture)
        {

        }
    }
}
