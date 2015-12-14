namespace LeGame.Handlers
{
    using LeGame.Engine;
    using LeGame.Interfaces;
    using LeGame.Models.Characters;

    using Microsoft.Xna.Framework;

    public static class MovementHandler
    {
        public static void MoveRight(ICharacter character)
        {
            if (character.Position.X + character.Speed <= GlobalVariables.WindowWidth - GfxHandler.GetWidth(character))
            {
                character.Position = new Vector2(character.Position.X + character.Speed, character.Position.Y);
            }
        }

        public static void MoveLeft(ICharacter character)
        {
            if (character.Position.X - character.Speed > 0)
            {
                character.Position = new Vector2(character.Position.X - character.Speed, character.Position.Y);
            }
        }

        public static void MoveUp(ICharacter character)
        {
            if (character.Position.Y - character.Speed > 0)
            {
                character.Position = new Vector2(character.Position.X, character.Position.Y - character.Speed);
            }
        }

        public static void MoveDown(ICharacter character)
        {
            if (character.Position.Y + character.Speed <= GlobalVariables.WindowHeight - GfxHandler.GetHeight(character))
            {
                character.Position = new Vector2(character.Position.X, character.Position.Y + character.Speed);
            }
        }     
    }
}
