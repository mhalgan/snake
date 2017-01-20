using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSNK
{
    class Map
    {
        private int[,] _map;
        private int _heigth;
        private int _width;

        public Map(int heigth, int width)
        {
            _heigth = heigth + 2; //Bordas
            _width = width + 2; //Bordas

            _map = new int[_heigth, _width];

            Console.Clear();
            for (int row = 0; row < _heigth; row++)
            {
                for (int column = 0; column < _width; column++)
                {
                    if (row == 0 || row == _heigth - 1 || column == 0 || column == _width - 1)
                    {
                        _map[row, column] = Constants.BORDER;
                    }
                }
            }
        }

        public void Show(int[] snakeHead)
        {
            Console.Clear();
            for (int row = 0; row < _heigth; row++)
            {
                for (int column = 0; column < _width; column++)
                {
                    if(row == 0 || row == _heigth - 1)
                    {
                        Console.Write("_");
                    }
                    else if (column == 0 || column == _width - 1)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        if (_map[row, column] == Constants.EMPTY)
                        {
                            Console.Write(" ");
                        }
                        else if (_map[row, column] == Constants.APPLE)
                        {
                            Console.Write("A");
                        }
                        else if(row == snakeHead[0] && column == snakeHead[1])
                        {
                            Console.Write("O");
                        }
                        else
                        {
                            Console.Write("*");
                        }
                    }
                }
                Console.WriteLine();
            }  
        }

        public void ShowCode()
        {
            Console.Clear();
            for (int row = 0; row < _heigth; row++)
            {
                for (int column = 0; column < _width; column++)
                {
                    if (_map[row, column] >= 0 && _map[row, column] < 100)
                    {
                        Console.Write(" " + _map[row, column]);
                    }
                    else
                    {
                        Console.Write(_map[row, column]);
                    }
                }
                Console.WriteLine();
            }
        }

        public int GetHeigth()
        {
            return _heigth;
        }

        public int GetWidth()
        {
            return _width;
        }

        public int[] GetMiddle()
        {
            int[] middlePosition = new int[2];
            middlePosition[0] = _heigth / 2;
            middlePosition[1] = _width / 2;

            return middlePosition;
        }

        public void Refresh()
        {
            for (int row = 0; row < _heigth; row++)
            {
                for (int column = 0; column < _width; column++)
                {
                    if(_map[row, column] > 0)
                    {
                        _map[row, column]--;
                    }
                }
            }
        }

        public void SetPosition(int[] coordinate, int value)
        {
            _map[coordinate[0], coordinate[1]] = value;
        }
        public int GetPosition(int[] coordinate)
        {
            return _map[coordinate[0], coordinate[1]];
        }

        public int[,] GetMap()
        {
            return _map;
        }
    }
}
