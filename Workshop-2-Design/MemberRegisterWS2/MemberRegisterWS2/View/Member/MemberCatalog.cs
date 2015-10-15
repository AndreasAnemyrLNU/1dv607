using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.V
{
    class MemberCatalog
    {
        private int i;
        
        public void outputCompactMemberCatalog(M.MemberCatalog memberCatalog)
        {
            //Console.Clear();
            Console.WriteLine();
            Console.Title = "Medlemskatalog";
            Console.WriteLine(" || Personnummer   || Förnamn        || Efternamn      || ");
            Console.WriteLine("----------------------------------------------------------");
            foreach(M.Member member in memberCatalog)
            {
                toggleTestBeforeSwapColor();

                Console.WriteLine(" || {2,-14} || {0,-14} || {1,-14} || ", member.FirstName, member.LastName, member.PersNr);
                System.Threading.Thread.Sleep(500);

                toggleUpAndReset();
            }
        }

        public void outputVerboseMemberCatalog(M.MemberCatalog memberCatalog, M.BoatCatalog boatCatalog)
        {
            foreach (M.Member member in memberCatalog)
            {
                toggleTestBeforeSwapColor();
              
                Console.WriteLine("================================\n");
                Console.WriteLine("Firstname- - - - - >>{0}", member.FirstName);
                Console.WriteLine("Lastname - - - - - >>{0}", member.LastName);
                Console.WriteLine("Personal Number- - >>{0}", member.PersNr);
                System.Threading.Thread.Sleep(500);

                foreach (M.Boat boat in boatCatalog.getReferencesOfMemberBoatsInBoatCatalog(member)) 
                {
                    Console.WriteLine("\nBoat list>{0}", member.FirstName);
                    Console.WriteLine("Type{0}", boat.Type);
                    Console.WriteLine("\n{0}",boat.Dim);
                    Console.WriteLine("");
                }
                Console.WriteLine("================================\n");

                toggleUpAndReset();
            }    
        }

        private void toggleTestBeforeSwapColor()
        {
            if (i % 2 == 0)
                Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        private void toggleUpAndReset() 
        {
            i++;
            Console.ResetColor();
        }

    }
}
