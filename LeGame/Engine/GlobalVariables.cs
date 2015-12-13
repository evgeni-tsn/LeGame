namespace LeGame
{
    using System;

    public static class GlobalVariables
    {
        public static readonly string ContentDir = @"..\..\..\Content\";

        public static readonly int TileWidth = 32;

        public static readonly int TileHeight = 32;

        public static readonly Random Rng = new Random();

        public static int WindowWidth { get; } = 800;

        public static int WindowHeight { get; } = 480;
    }
}
