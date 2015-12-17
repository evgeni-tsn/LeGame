using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Interfaces
{
   public  interface IStat
    {
        void Draw(ICharacter character, SpriteBatch spriteBatch);

    }
}
