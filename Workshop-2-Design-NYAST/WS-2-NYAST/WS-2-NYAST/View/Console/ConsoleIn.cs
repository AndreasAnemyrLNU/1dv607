using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WS_2_NYAST.View
{
    public class ConsoleIn
    {
        public int readKeyToInt()
        {            
            return (int)Console.ReadKey(true).KeyChar - 48;
        }

        public string readString()
        {
            return Console.ReadLine();
        }

        public string ResponseToAskedQustion(string question)
        {
            Console.WriteLine();
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public char ResponseToAskedQustionNonEnterPress(string question)
        {
            Console.WriteLine();
            Console.WriteLine(question);
            return (char)Console.ReadKey(true).KeyChar;
        }

        /// <summary>
        /// Ask Cliet something and get a true or false returned :) Requires + Enter press!
        /// </summary>
        /// <param name="question">Your question to client</param>
        /// <param name="validChars">Thes letters returns true if pressed</param>
        /// <returns></returns>
        public bool boolResponseOfQuestion(string question, string validChars)
        {
            string input = ResponseToAskedQustionNonEnterPress(question).ToString();

            string pattern = @"[" + validChars + "]";

            Match match = Regex.Match(input, pattern, RegexOptions.IgnoreCase);

            if (match.Success)
                return true;

            return false;
        }

        // Start Region :: Interaction...
        public const string FAQContinueWithY    = "(y) Continue?";
        public const string FAQCancelWithN      = "(n) Cancel?) ?";
        public const string FAQProceedUnlock    = "(y) Unlock data and start edit?";
        public const string FAQPreviousValue = "(y) Previous value was {0}. Update?";
        // End  Regions :: Interaction...

        // Start Region :: FAQ Menus
        public const string FAQTakeMeToMenuMain = "(y) Take me to Menu \"Main\"   ?";
        public const string FAQGTakeMeToMenuMember = "(y) Take me to Menu \"Member\" ?";
        public const string FAQGTakeMeToMenuQuit = "(y) Take me to menu \"Quit\"   ?";
        public const string FAQGTakeMeToMenuBoat = "(y) Take me to menu \"Boat\"   ?";
        public const string FAQGTakeMeToMenuSave = "(y) Take me to menu \"Save\"   ?";
        // End Region :: FAQ Menus

        // Start Region :: Member
        public const string FAQMemberWhatsFirstName = "What´s the firstname of member?";
        public const string FAQwhatsLastName = "What´s the lastname of member?";
        public const string FAQwhatsSSN = "What´s the SSN of member?";
        public const string FAQMemberReallyDelete = "(y) Really, delete meber? : ";
        public const string FAQMemberReallyUpdate = "(y) Really, edit/update member? : ";
        public const string FAQMemberWasCreated = "This Member was created!";
        public const string FAQMemberWasDeleted = "This Member was deleted!";
        public const string FAQMemberWasUpdated = "This Member was updated!";
        public const string FAQMemberWasFoundBySSN = "This Member was found by SSN!";
        public const string FAQMemberWasNotFoundBySSN = "Member was NOT found by SSN!";
        public const string FAQMemberContinueCreating = "(y) Continue creating member?";
        public const string FAQMemberContinueUpdating = "(y) Continue updating another member?";
        public const string FAQMemberContinueReading = "(y) Continue reading another member?";
        public const string FAQMemberContinueDeleting = "(y) Continue deliting another member?";
        // End Regions :: Member

        // Start Region :: Boat
        public const string FAQBoatAddSSN = "Add SSN (groupid) for this boat";
        public const string FAQBoatType = "Pick one type of boat: \n\n(1)Sailboat\n(2)Motorsailer\n(3)Kayak/Canoe\n(4)Other";
        public const string FAQBoatNewSSN = "Enter a new SSN for an existing Member to change owner";
        public const string FAQBoatLength = "What's the length of boat (cm)?";
        public const string FAQBoatTypeOfBoat = "Type of boat : {0}";
        public const string FAQBoatLengthOfBoat = "Boat has an length of {0} cm";
        public const string FAQBoatBoatsfounByGroup = "These boats belongs to : {0}";
        public const string FAQBoatBoatsNrToEdit = "Want to edit?  Press {0}";
        public const string FAQBoatWhichtoEdit = "Enter the boat you wan't to edit.\n(Enter digit from list of boats above.";
        public const string FAQBoatWhichtoDelete = "Enter the boat you wan't to delete.\n(Enter digit from list of boats above.";
        public const string FAQBoatWasUpdated = "This Boat was updated!";
        public const string FAQBoatAddMoreBoats = "(y) Add yet another boat?";
        // End Region   :: Boat

        // Start Region :: Quit
        public const string FAQQuitMessage = "Application quits in {0} millissecs!";
        // End Region   :: Quit
    }
}