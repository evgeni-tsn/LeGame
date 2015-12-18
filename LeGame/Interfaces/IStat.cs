using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Interfaces
{
   public  interface IStat
   {
       SpriteFont Font { get; set; }
       void Load(ContentManager content);
       void Draw(ICharacter character, SpriteBatch spriteBatch);

    }
}
