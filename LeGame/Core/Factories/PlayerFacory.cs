namespace LeGame.Core.Factories
{
    using LeGame.Handlers;
    using LeGame.Interfaces;
    using LeGame.Models.Characters.Player;

    using Microsoft.Xna.Framework;

    using static GlobalVariables;

    public static class PlayerFacory
    {
        public static ICharacter MakePlayer(string type)
        {
            ICharacter player;
            switch (type)
            {
                case "The Guy":
                    player = new TheGuy();
                    break;
                case "Redhead":
                    player =  new Redhead();
                    break;
                default:
                    player =  new Blondy();
                    break;
            }

            player.Died += (sender, args) => GfxHandler.AddDeathEffect(sender);
            player.Damaged += (sender, args) => GfxHandler.AddBloodEffect(sender);

            return player;
        }
    }
}
