using System;
using System.Drawing;
using System.Text;

namespace GOL
{
    class Board
    {
        public int Width;
        public int Height;

        public Cell[][] Cells;

        public Board(int w, int h) : this(CreateBaseState(w, h))
        {

        }

        public static Cell.State[][] CreateBaseState(int w, int h)
        {
            var rng = new Random();
            var source = new Cell.State[h][];

            for (int y = 0; y < h; y++)
            {
                source[y] = new Cell.State[w];
                Cell.State[] row = source[y];

                for (int x = 0; x < row.Length; x++)
                {
                    int max = (int)Cell.State.MAX;

                    //if (x < 5 || x > 15 ||
                    //    y < 5 || y > 15)
                    //    max = (int)Cell.State.Dead;

                    row[x] = (Cell.State)rng.Next(max);
                }
            }
            return source;
        }

        public Board(Cell.State[][] source)
        {
            Height = source.Length;
            Width = source[0].Length;

            Cells = new Cell[Height][];

            for (int y = 0; y < Cells.Length; y++)
            {
                Cells[y] = new Cell[Width];
                Cell[] row = Cells[y];

                for (int x = 0; x < row.Length; x++)
                {
                    row[x] = new Cell(source[y][x]);
                }
            }
        }

        public (int x, int y) WrapIndex(int x, int y)
        {
            if (x < 0)
                x = Width - 1;
            if (x >= Width)
                x = 0;
            if (y < 0)
                y = Height - 1;
            if (y >= Height)
                y = 0;

            return (x, y);
        }

        public int Neighbours(int cx, int cy)
        {
            int neighbours = 0;

            for (int y = -1; y <= 1; y++)
            {

                int ny = y + cy;

                for (int x = -1; x <= 1; x++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    int nx = x + cx;

                    var (ax, ay) = WrapIndex(nx, ny);

                    if (Cells[ay][ax].state == Cell.State.Alive)
                        neighbours++;
                }

            }

            return neighbours;
        }

        public void Update()
        {
            for (int y = 0; y < Cells.Length; y++)
            {
                Cell[] row = Cells[y];

                for (int x = 0; x < row.Length; x++)
                {
                    var cell = row[x];

                    int neighbours = Neighbours(x, y);
                    cell.neighbours = neighbours;


                }
            }

            for (int y = 0; y < Cells.Length; y++)
            {
                Cell[] row = Cells[y];
                /*
                 * Any live cell with two or three live neighbours survives.
Any dead cell with three live neighbours becomes a live cell.
All other live cells die in the next generation. Similarly, all other dead cells stay dead.*/
                for (int x = 0; x < row.Length; x++)
                {
                    var cell = row[x];

                    if (cell.state == Cell.State.Alive)
                    {
                        if (cell.neighbours >= 2 && cell.neighbours < 4)
                            continue;
                    }
                    else
                    {
                        if (cell.neighbours == 3)
                        {
                            cell.state = Cell.State.Alive;
                            continue;
                        }

                    }
                    cell.state = Cell.State.Dead;
                }
            }
        }

        public void Draw()
        {
            var builder = new StringBuilder();

            Console.SetCursorPosition(0, 0);

            for (int y = 0; y < Cells.Length; y++)
            {
                Cell[] row = Cells[y];

                for (int x = 0; x < row.Length; x++)
                {
                    var cell = row[x];

                    switch (cell.state)
                    {
                        case Cell.State.Dead:
                            builder.Append(" ");
                            break;
                        case Cell.State.Alive:
                            builder.Append("O");
                            break;

                    }
                }

                builder.AppendLine();
            }

            Console.WriteLine(builder);
        }
    }
}
