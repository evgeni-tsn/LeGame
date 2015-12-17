namespace LeGame.Core.Factories
{
    using System.Collections.Generic;

    using LeGame.Interfaces;
    using LeGame.Models.Items.PickableItems;

    using Microsoft.Xna.Framework;

    public static class ItemFactory
    {
        public static IEnumerable<PickableItem> MakeItems()
        {
            return new PickableItem[]
                       {
                           new GoldCoin(new Vector2(300, 300), "TestObjects/coin"),
                           new Steak(new Vector2(448, 150), "Items/Steak")
                       };
        }
    }
}
