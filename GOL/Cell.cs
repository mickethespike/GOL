using System.Diagnostics;

namespace GOL
{
    [DebuggerDisplay("{ToString()}")]
    public class Cell
    {
        public enum State
        {
            Dead,
            Alive,
            MAX
        };

        public State state;
        public int neighbours;



        public Cell(State s)
        {
            state = s;
        }

        public override string ToString()
        {
            return state + ": " + neighbours;
        }
    }
}