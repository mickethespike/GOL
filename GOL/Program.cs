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
            //Cell.State[][] initial =
            //{
            //    new [] { X, X, X, X, X, X, X, X, X, X, X, X, X, X, X, X },
            //    new [] { X, X, X, X, X, X, X, X, X, X, X, X, X, X, X, X },
            //    new [] { X, X, X, X, X, X, X, X, X, X, X, X, X, X, X, X },
            //    new [] { X, X, X, X, X, X, X, X, X, X, X, X, X, X, X, X },
            //    new [] { X, X, X, X, X, X, O, O, X, X, X, X, X, X, X, X },
            //    new [] { X, X, X, X, X, X, O, X, X, X, X, X, X, X, X, X },
            //    new [] { X, X, X, X, X, X, X, X, X, O, X, X, X, X, X, X },
            //    new [] { X, X, X, X, X, X, X, X, O, O, X, X, X, X, X, X },
            //    new [] { X, X, X, X, X, X, X, X, X, X, X, X, X, X, X, X },
            //    new [] { X, X, X, X, X, X, X, X, X, X, X, X, X, X, X, X },
            //};
            Cell.State[][] initial =
            {
                new [] { X, X, X, X, X, X },
                new [] { X, O, O, X, X, X },
                new [] { X, O, X, X, X, X },
                new [] { X, X, X, X, O, X },
                new [] { X, X, X, O, O, X },
                new [] { X, X, X, X, X, X }
            };
            //Board board = new Board(initial);
            Board board = new Board(60, 40, false);

            while (true)
            {
                board.Draw();
                board.Update();
                Thread.Sleep(100);
            }
        }
    }
}
