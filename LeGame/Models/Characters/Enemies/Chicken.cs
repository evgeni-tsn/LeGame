namespace LeGame.Models.Characters.Enemies
{
    using System;

    using Handlers;
    using Interfaces;
    using Items.Weapons;

    using Microsoft.Xna.Framework;

    public class Chicken : Enemy
    {
        private const string ChickenDefaultType = "TestObjects/cockSprite";

        private const int ChickenDefaultMaxHealth = 100;

        private const int ChickenDefaultCurrentHealth = 100;

        private const int ChickenDefaultSpeed = 2;

        public Chicken(Vector2 position, Level level)
            : base(position, ChickenDefaultType, ChickenDefaultMaxHealth, ChickenDefaultCurrentHealth, ChickenDefaultSpeed, level)
        {
        }
    }
}
