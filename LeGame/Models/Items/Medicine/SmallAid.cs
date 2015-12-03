using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LeGame.Models.Items.Medicine
{
    public class SmallAid : Medicine
    {
        public SmallAid(Vector2 position, string displayName, int healingAmount, Texture2D texture)
            : base(position, displayName, healingAmount, texture)
        {
        }
    }
}