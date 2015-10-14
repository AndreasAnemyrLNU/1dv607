using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WS_2_NYAST.View
{
    class ConsoleIn
    {
        public int readKeyToInt()
        {
            return (int)Console.ReadKey(true).KeyChar -48;
        
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

            string pattern = @"[" +validChars+ "]";

            Match match = Regex.Match(input, pattern, RegexOptions.IgnoreCase);

            if (match.Success)
                return true;

            return false;
        }
    
        // Start Region :: Interaction...
        public const string FAQContinueWithY        = "(y) Continue?";
        public const string FAQCancelWithN          = "(n) Cancel?) ?";
        // End  Regions :: Interaction...

        // Start Region :: FAQ Menus
        public const string FAQTakeMeToMenuMain     = "(y) Take me to Menu \"Main\"   ?";
        public const string FAQGTakeMeToMenuMember  = "(y) Take me to Menu \"Member\" ?";
        public const string FAQGTakeMeToMenuQuit    = "(y) Take me to menu \"Quit\"   ?";
        public const string FAQGTakeMeToMenuBoat    = "(y) Take me to menu \"Boat\"   ?";
        public const string FAQGTakeMeToMenuSave    = "(y) Take me to menu \"Save\"   ?";
        // End Region :: FAQ Menus

        // Start Region :: Member
        public const string FAQMemberWhatsFirstName = "What´s the firstname of member?";
        public const string FAQwhatsLastName        = "What´s the lastname of member?";
        public const string FAQwhatsSSN             = "What´s the SSN of member?";
        public const string FAQMemberReallyDelete   = "(y) Really, delete meber? : ";
        public const string FAQMemberReallyUpdate   = "(y) Really, eidt/update memer? : ";
        public const string FAQMemberWasDeleted     = "This Member was deleted!";
        public const string FAQMemberWasUpdated     = "This Member was updated!";
        public const string FAQMemberWasFoundBySSN  = "This Member was found by SSN!";
        public const string FAQMemberPreviousValue  = "(y) Previous value was {0}. Update?";
        // End Regions :: Member

        // Start Region :: Boat
        public const string FAQBoatType             = "Pick one type of boat: \n\n(0)Sailboat\n(1)Motorsailer\n(2)Kayak/Canoe\n(3)Other";
        public const string FAQMemberWasFoundBySSN  = "This boat was was saved";
        // End Region   :: Boat

        // Start Region :: Quit
        public const string FAQQuitMessage          = "Application quits in {0} millissecs!";
        // End Region :: Quit

        public const string FAQBoatLength           = "What's the length of boat (cm)?";             
}
