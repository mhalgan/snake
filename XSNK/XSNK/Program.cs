using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSNK
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 57);
            Controller controller = new Controller();
            controller.Start();

            while(!controller.End());
        }
        

    }
}
