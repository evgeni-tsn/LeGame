namespace LeGame.Core
{
    using System;

    public static class GlobalVariables
    {
        public const string ContentDir = @"..\..\..\Content\";

        public const float DownAngle = 3.15f;

        public const float LeftAngle = -1.55f;

        public const float RightAngle = 1.55f;

        public const int TileHeight = 32;

        public const int TileWidth = 32;

        public const float UpAngle = 0f;

        public static readonly Random Rng = new Random();

        public static int GlobalTimer = 0;

        public static int WindowHeightDefault { get; } = 480;

        public static int WindowWidthDefault { get; } = 800;
    }
}