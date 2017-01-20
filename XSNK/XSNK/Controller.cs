using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace XSNK
{
    class Controller
    {
        private Map map;
        private Timer timer;
        private Snake snake;
        private Input input;
        private int[] snakeHead;
        private int[] applePosition;
        private Apple apple;
        private bool end;
        private bool showCode;

        public Controller()
        {
            map = new Map(40,40);
            snake = new Snake(3);
            timer = new Timer(100);
            input = new Keyboard();
            apple = new Apple();

            snakeHead = new int[2];
            applePosition = new int[2];
            showCode = false;

            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        public void Start()
        {
            end = false;
            snakeHead = map.GetMiddle();
            snake.Respawn(snakeHead);
            timer.Start();
            do
            {
                applePosition = apple.Spawn(map.GetHeigth(), map.GetWidth());
            } while (map.GetPosition(applePosition) != Constants.EMPTY);
            map.SetPosition(applePosition, Constants.APPLE);
        }

        public bool End()
        {
            return end;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Command command = input.GetCommand();
            snake.Turn(command);
            snakeHead = snake.Move();
            map.Refresh();
            if (Collision())
            {
                if (map.GetPosition(snakeHead) == Constants.BORDER || map.GetPosition(snakeHead) > Constants.EMPTY)
                {
                    GameOver();
                    end = true;
                    timer.Stop();
                }

                if (map.GetPosition(snakeHead) == Constants.APPLE)
                {
                    snake.Eat();
                    map.SetPosition(applePosition, snake.GetSize() - 1);
                    do
                    {
                        applePosition = apple.Spawn(map.GetHeigth(), map.GetWidth());
                    } while (map.GetPosition(applePosition) != Constants.EMPTY);
                    map.SetPosition(applePosition, Constants.APPLE);
                    map.SetPosition(snakeHead, snake.GetSize());
                    if(showCode)
                    {
                        map.ShowCode();
                    }
                    else
                    {
                        map.Show(snakeHead);
                    }
                }  
            }
            else
            {
                map.SetPosition(snakeHead, snake.GetSize());
                if (showCode)
                {
                    map.ShowCode();
                }
                else
                {
                    map.Show(snakeHead);
                }
            }

            Console.WriteLine(command);
        }

        private bool Collision()
        {
            int snakeHeadValue = map.GetPosition(snakeHead);
            bool isCollision = true;
            if (snakeHeadValue == Constants.EMPTY)
            {
                isCollision = false;
            }
            return isCollision;
        }

        private void GameOver()
        {
            Console.WriteLine("GAME OVER");
        }

    } 
}
