using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.View
{
    class Boat : WS2_NEW.View.Crud
    {
        private const string Title = ":::   Boats!";

        public override void setRequest()
        {
            Console.WindowHeight = 25;
            Console.WindowWidth = 40;
            TitleOut(Title);

            // Region Start :: Menu Selections
            Console.WriteLine("     1 New");
            Console.WriteLine("     2 View");
            Console.WriteLine("     3 Edit");
            Console.WriteLine("     4 Erase\n");
            Console.WriteLine("     5 Go to Catalog of Boats");
            Console.WriteLine("     6 Go back to Index Page\n");
            Console.WriteLine("     Enter your choice, plz!\n\n");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("     ");
            Console.ResetColor();
            // Region End :::: Menu Selections
        }

        public override string getResponse()
        {
            return Console.ReadLine();
        }

        public override void Create()
        {
            throw new NotImplementedException();
        }

        public override void Read()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
