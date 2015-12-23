namespace LeGame.Core.Factories
{
    using System.Collections.Generic;

    using LeGame.Interfaces;
    using LeGame.Models.Items.PickableItems;
    using LeGame.Models.Items.Weapons;

    using Microsoft.Xna.Framework;

    public static class ItemFactory
    {
        public static IEnumerable<PickableItem> MakeTestItems()
        {
            return new PickableItem[]
                       {
                           new GoldCoin(new Vector2(300, 300), "TestObjects/coin"), new Steak(new Vector2(448, 150)), 
                           new LightningStaff(new Vector2(50, 50)), new LaserGun(new Vector2(100, 50)), 
                           new IceSpear(new Vector2(150, 50)), 
                       };
        }

        internal static void SpawnPotionByChance(object sender)
        {
            switch (GlobalVariables.Rng.Next(0, 10))
            {
                // Lucky numbers s73vin
                case 7:
                    var riper = sender as ICharacter;
                    riper?.Level.Assets.Add(new RedPotion(riper.Position));
                    break;
                case 3:
                    riper = sender as ICharacter;
                    riper?.Level.Assets.Add(new OrangePotion(riper.Position));
                    break;
            }
        }
    }
}