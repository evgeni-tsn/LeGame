namespace LeGame.Handlers
{
    using Core;
    using Interfaces;
    using Microsoft.Xna.Framework;

    public static class MovementHandler
    {
        public static void MoveRight(ICharacter character, float speedModifier = 1f)
        {
            if (character.Position.X + character.Speed <= GlobalVariables.WindowWidthDefault - GfxHandler.GetWidth(character))
            {
                character.Position = new Vector2(character.Position.X + (character.Speed * speedModifier), character.Position.Y);
            }
        }

        public static void MoveLeft(ICharacter character, float speedModifier = 1f)
        {
            if (character.Position.X - character.Speed > 0)
            {
                character.Position = new Vector2(character.Position.X - (character.Speed * speedModifier), character.Position.Y);
            }
        }

        public static void MoveUp(ICharacter character, float speedModifier = 1f)
        {
            if (character.Position.Y - character.Speed > 0)
            {
                character.Position = new Vector2(character.Position.X, character.Position.Y - (character.Speed * speedModifier));
            }
        }

        public static void MoveDown(ICharacter character, float speedModifier = 1f)
        {
            if (character.Position.Y + character.Speed <= GlobalVariables.WindowHeightDefault - GfxHandler.GetHeight(character))
            {
                character.Position = new Vector2(character.Position.X, character.Position.Y + (character.Speed * speedModifier));
            }
        }     
    }
}
