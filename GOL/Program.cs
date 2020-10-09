using System;
using System.Threading;

namespace GOL
{
    class Program
    {
        static void Main(string[] args)
        {
            var X = Cell.State.Dead;
            var O = Cell.State.Alive;
            Cell.State[][] initial =
            {
                // Fill with patterns in `PATTERNS.md`
            };

            //Board board = new Board(initial, false);
            Board board = new Board(Console.WindowWidth - 2, Console.WindowHeight - 2, false);

            Console.Title = Convert.ToString(board.Seed);

            while (true)
            {
                board.Draw();
                board.Update();
                Thread.Sleep(100);
            }
        }
    }
}