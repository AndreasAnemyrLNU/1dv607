using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MemberRegisterWS2
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller.Root rootController = new Controller.Root(new View.Menu());
            rootController.DoApplication();
        }
    }
}
