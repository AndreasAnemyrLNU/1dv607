using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.View
{
    class Error
    {
        public Error(Exception e) 
        {
            ShowIt(e);
        }

        public Error(string errMessage)
        {
            ShowIt(errMessage);
        }

        private void ShowIt(Exception e) 
        {
            Console.WriteLine(e.Message);
        }

        private void ShowIt(string errMessage)
        {
            Console.WriteLine(errMessage);
        }

        public const string ErroMessageNonExistingMember = "Non existing user for your input!";
        public const string ErroMessageAlreadyExistingMember = "Already existing user!";


    }
}
