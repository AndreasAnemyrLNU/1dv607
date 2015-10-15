using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.V
{
    class CommonQuestions
    {
        protected const string AskForInt = "\nInstruktion\nAnge siffra i meny\nMed \"Enter\" bekräftas val : ";

        public string AskForInput(string messageToClient)
        {
            //Exec Question to Client for data
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(messageToClient);
            Console.ResetColor();

            string dataInputFromClient = Console.ReadLine();

            Console.WriteLine();
            System.Threading.Thread.Sleep(300);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0}", string.Concat(Enumerable.Repeat("*", Console.WindowWidth)));
            Console.Write("{0}", string.Concat(Enumerable.Repeat("*", Console.WindowWidth)));
            System.Threading.Thread.Sleep(300);
            Console.WriteLine();

            Console.ResetColor();

            return dataInputFromClient;
        }

        public void ShowMember(M.Member member, string preMessage, int nrOfBoatsOwnedByMember = 0)
        {
            Console.WriteLine("{0}", preMessage);
            Console.WriteLine(member.ToString());
            Console.WriteLine();
            Console.Write("Members has today ");
            Console.Write(nrOfBoatsOwnedByMember);
            Console.Write(" boat(s)\n");
        }

        public bool askClientBeforeDelete(string str)
        {
            while (true)
            {
                Console.Write("\nDo you wanna Delete {0} ? \n\n y/n ", str);

                try
                {
                    string key = Console.ReadLine();

                    if (key == "y" || key == "Y")
                    {
                        Console.WriteLine();
                        return true;
                    }

                    if (key != "y" || key != "Y" || key != "n" || key != "N")
                    {
                        throw new Exception("Please: Enter y or Y or n or N. \nThank you!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}
