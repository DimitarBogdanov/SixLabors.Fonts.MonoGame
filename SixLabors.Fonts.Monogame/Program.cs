using System;

namespace SixLabors.Fonts.Monogame.Testing
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1()) game.Run();
        }
    }
}