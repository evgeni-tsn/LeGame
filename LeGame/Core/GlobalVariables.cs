using System;

namespace LeGame.Core
{
    public static class GlobalVariables
    {
        public static readonly Random Rng = new Random();

        public static int GlobalTimer = 0;

        public const string ContentDir = @"..\..\..\Content\";

        public const int TileWidth = 32;

        public const int TileHeight = 32;

        public static int WindowWidthDefault { get; } = 800;

        public static int WindowHeightDefault { get; } = 480;

        public const float RightAngle = 1.55f;

        public const float LeftAngle = -1.55f;

        public const float UpAngle = 0f;

        public const float DownAngle = 3.15f;
    }
}
