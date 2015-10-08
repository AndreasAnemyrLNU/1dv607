using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.View
{
    class Index : View
    {
        private const string Title = "  Welcome to Boats & Members -SuperGUI  ";

        public override void setRequest()
        {
            Console.WindowHeight = 25;
            Console.WindowWidth = 40;
            TitleOut(Title);
        
            // Region Start :: Menu Selections
            Console.WriteLine("     1 Boat    (CRUD)");
            Console.WriteLine("     2 Member  (CRUD)");
            Console.WriteLine("     3 Save" );
            Console.WriteLine("     4 Quit\n");
            Console.WriteLine("     Enter your choice, plz!\n\n");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write    ("     ");
            Console.ResetColor();
            // Region End :::: Menu Selections
        }

        public override string getResponse(string question = null, bool completelylOwnFormattedQuestion = false)
        {
            return Console.ReadLine();
        }
    }
}
