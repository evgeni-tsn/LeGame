namespace LeGame
{
    using System;

    using Core;

    public static class RolePlayingGame
    {
        [STAThread]
        private static void Main()
        {
            GameEngine game = new GameEngine();
            game.Run();
        }
    }
}
