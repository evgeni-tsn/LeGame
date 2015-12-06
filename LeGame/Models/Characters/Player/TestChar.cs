using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeGame.Handlers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Models.Characters.Player
{
    public class TestChar : Player
    {
        //private Level level;
        //private AnimatedSprite sprite;

        
        public TestChar(Vector2 position, string type, int maxHealth, int currentHealth, int speed, Level level)
            : base(position, type, maxHealth, currentHealth, speed, level)
        {
            
        }
        
        

        
    }
}
