using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.View
{
    class Member : Crud
    {
        public const string WarningMessageUpdateMemberField = "Really? \n You want't to edit \n {0}: {1} \nto something elses? \n\n Enter Y (yes)?";
        public const string WarningMessageNonexistingMember = "\n Oh no! \n -Member does not exist!";
        public const string NormalMessageMemberWillbeDeleted = "\n -What! \n\n -Do really want to delete";
        public const string NormalMessageFAQNeedSSN = "\n You need to know \n personal number \n for the member to update!\n ";
        public const string WarningMessageCancelationHasHappened = " Onooo -Really!? \n You did wrong maybe \n or what ??? \n Maybe try one more time :)";
       
        public void ShouldLookLikeTheConsoleIsWarningForWhatHappened(string msg)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(msg);
            Console.ResetColor();
        } 

        private const string Title = ":::   Members!";

        public override void setRequest()
        {
            Console.Clear();
            Console.WindowHeight = 25;
            Console.WindowWidth = 40;
            TitleOut(Title);

            // Region Start :: Menu Selections
            Console.WriteLine("     1 New");
            Console.WriteLine("     2 View");
            Console.WriteLine("     3 Edit");
            Console.WriteLine("     4 Erase\n");
            Console.WriteLine("     5 Go to Catalog of Members");
            Console.WriteLine("     6 Go back to Index Page\n");
            Console.WriteLine("     Enter your choice, plz!\n\n");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("     ");
            Console.ResetColor();
            // Region End :::: Menu Selections
        }

        public void consoleWriteMember(Model.Member member, bool isCachedNow = false) 
        {
            try 
            {
                if (isCachedNow) 
                {
                    YouDidQuitSomeCruddyThingToHappenAndSystemsShowItToClient("\nYou've cached this now:");
                }

                Console.Write(string.Format("\n\nFirstname:{0,23}\nLastname:{1,24}\nPersNr: {2,25}\n", member.FirstName, member.LastName, member.PersonalNumber));
            }
            catch 
            {
                Console.WriteLine(WarningMessageNonexistingMember);
            }            
        }

        public void YouDidQuitSomeCruddyThingToHappenAndSystemsShowItToClient(string msg)
        {
            ShouldLookLikeTheConsoleIsWarningForWhatHappened(msg);
        }

        public string DoYouReallyWantToUpdate(string message, Model.FieldInModelMember field , Model.Member member) 
        {
            //TODO fieldToUpdate enums maybe?
            // name of field hardcodend. Better solution for this?

            switch(field) 
            {
                case Model.FieldInModelMember.firsName:
                    return string.Format(message, "firstname", member.FirstName);
                case Model.FieldInModelMember.lastName:
                    return string.Format(message, "lastname", member.LastName);
                case Model.FieldInModelMember.SSN:
                    return String.Format(message, "SSN", member.PersonalNumber);
                default:
                    return string.Empty;
            }
                
        }
    }
}
