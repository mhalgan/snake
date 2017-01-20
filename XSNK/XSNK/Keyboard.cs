using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace XSNK
{
    class Keyboard : Input
    {
        private ConsoleKeyInfo _key;
        private Thread thread;

        public Keyboard()
        {
            thread = new Thread(work);
            thread.Start();
        }

        private void work()
        {
            while (true)
            {
                SetKey(Console.ReadKey());
            }
        }

        private void SetKey(ConsoleKeyInfo key)
        {
            _key = key;
        }
        public Command GetCommand()
        {
            Command command = Command.None;

            if (_key.Key == ConsoleKey.UpArrow)
            {
                command = Command.Up;
            }
            else if (_key.Key == ConsoleKey.DownArrow)
            {
                command = Command.Down;
            }
            else if (_key.Key == ConsoleKey.LeftArrow)
            {
                command = Command.Left;
            }
            else if (_key.Key == ConsoleKey.RightArrow)
            {
                command = Command.Right;
            }


            return command;
        }
    }
}
