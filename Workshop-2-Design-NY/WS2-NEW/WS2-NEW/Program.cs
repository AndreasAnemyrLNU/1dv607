using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW
{
    class Program
    {
    
        static void Main(string[] args)
        {
            Interface.IController controller = new Controller.Index() as Interface.IController;
            controller.DoApplication();

            Console.ReadKey();
        }
    }
}
 