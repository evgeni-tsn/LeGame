namespace LeGame.Core.Factories
{
    using LeGame.Enumerations;
    using LeGame.Exceptions;
    using LeGame.Handlers;
    using LeGame.Interfaces;
    using LeGame.Models.Characters.Player;
    
    public static class PlayerFacory
    {
        public static ICharacter MakePlayer(PlayerChars type)
        {
            ICharacter player;
            switch (type)
            {
                case PlayerChars.TheGuy:
                    player = new TheGuy();
                    break;
                case PlayerChars.Redhead:
                    player = new Redhead();
                    break;
                case PlayerChars.Blondy:
                    player = new Blondy();
                    break;
                default:
                    throw new CharacterException($"{typeof(PlayerFacory).Name} does not contain such character.");
            }

            player.Died += (sender, args) => GfxHandler.AddDeathEffect(sender);
            player.Damaged += (sender, args) => GfxHandler.AddBloodEffect(sender);

            return player;
        }
    }
}
