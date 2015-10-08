using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.View
{
    class Member : Crud
    {
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


    }
}
