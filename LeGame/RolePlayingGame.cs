using System;
using LeGame.Engine;

namespace LeGame
{
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
