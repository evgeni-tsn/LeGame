using Microsoft.Xna.Framework;

namespace LeGame.Models.Items.Medicine
{
    public class SmallAid : Medicine
    {
        public SmallAid(Vector2 position, string displayName, int healingAmount) : base(position, displayName, healingAmount)
        {
        }
    }
}