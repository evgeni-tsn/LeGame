using System;

namespace LeGame
{
    public static class RolePlayingGame
    {
        [STAThread]
        private static void Main()
        {
            var game = new GameEngine();
            game.Run();
        }
    }
}
