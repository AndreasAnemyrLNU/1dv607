using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.V
{
    class baseMember
    {
        protected const string AskForInt = "\nInstruktion\nAnge siffra i meny\nMed \"Enter\" bekräftas val : ";    
        
        protected string AskForInput(string messageToClient)
        {
            //Exec Question to Client for data
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(messageToClient);
            Console.ResetColor();

            string dataInputFromClient = Console.ReadLine();

            Console.WriteLine();
            System.Threading.Thread.Sleep(300);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0}", string.Concat(Enumerable.Repeat("*", Console.WindowWidth)) );
            Console.Write("{0}", string.Concat(Enumerable.Repeat("*", Console.WindowWidth)));
            System.Threading.Thread.Sleep(300);
            Console.WriteLine();

            Console.ResetColor();

            return dataInputFromClient;
        }

        public void ShowMember(M.Member member, string preMessage) 
        {
            Console.WriteLine("{0}", preMessage);
            Console.WriteLine(member.ToString());
        }
    }
}
