using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSNK
{
    public enum GameState
    {
        Inactive,
        Active,
        Paused,
        Terminated
    }

    public enum Command
    {
        Left,
        Right,
        Up,
        Down,
        None
    }

    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
}
