using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.View
{
    class common
    {
        public string askForInput(string messageToClient)
        {
            //Exec Question to Client for data
            Console.WriteLine(messageToClient);
            string dataInputFromClient = Console.ReadLine();
            return dataInputFromClient;
        }
    }
}
