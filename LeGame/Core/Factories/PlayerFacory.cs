namespace LeGame.Core.Factories
{
    using LeGame.Handlers;
    using LeGame.Interfaces;
    using LeGame.Models.Characters.Player;

    using Microsoft.Xna.Framework;

    using static GlobalVariables;

    public static class PlayerFacory
    {
        public static ICharacter MakeRandomPlayer()
        {
            var randomPosition = new Vector2(Rng.Next(50, WindowWidthDefault - 50), Rng.Next(50, WindowHeightDefault - 250));
            ICharacter player;
            switch (Rng.Next(0, 2))
            {
                case 0:
                    player = new TheGuy(randomPosition);
                    break;
                case 1:
                    player =  new Redhead(randomPosition);
                    break;
                default:
                    player =  new Blondy(randomPosition);
                    break;
            }

            player.Died += (sender, args) => GfxHandler.AddDeathEffect(sender);
            player.Damaged += (sender, args) => GfxHandler.AddBloodEffect(sender);

            return player;
        }
    }
}
