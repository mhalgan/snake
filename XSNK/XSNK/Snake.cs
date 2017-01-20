using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSNK
{
    class Snake
    {
        private int _size;
        private int[] head;
        private int[] tail;
        private Direction direction;

        public Snake(int size)
        {
            head = new int[2];
            tail = new int[2];

            _size = size;
        }

        public void Respawn(int[] position)
        {
            head[0] = position[0];
            head[1] = position[1];
        }

        public void Turn(Command command)
        {
            if (direction == Direction.Left || direction == Direction.Right)
            {
                if (command == Command.Up)
                {
                    direction = Direction.Up;
                }
                else if (command == Command.Down)
                {
                    direction = Direction.Down;
                }
            }
            else if (direction == Direction.Up || direction == Direction.Down)
            {
                if (command == Command.Left)
                {
                    direction = Direction.Left;
                }
                else if (command == Command.Right)
                {
                    direction = Direction.Right;
                }
            }
        }
        public int[] Move()
        {
            if(direction == Direction.Up)
            {
                head[0]--;
            }
            else if(direction == Direction.Down)
            {
                head[0]++;
            }
            else if(direction == Direction.Left)
            {
                head[1]--;
            }
            else if(direction == Direction.Right)
            {
                head[1]++;
            }

            return head;
        }

        public int GetSize()
        {
            return _size;
        }

        public void Eat()
        {
            _size++;
        }
    }
}
