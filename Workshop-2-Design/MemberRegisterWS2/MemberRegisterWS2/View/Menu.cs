using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.View
{
    class Menu
    {

        public void Welcome()
        {
            Console.WriteLine("Välkommen till Medlemsregistret!");
            Console.WriteLine("                                ");
            Console.WriteLine("================================");
            Console.WriteLine("                                ");
            Console.WriteLine("Medlemmar                       ");
            Console.WriteLine("                                ");
            Console.WriteLine("Välj med siffra vad du vill göra");
            Console.WriteLine("1 - Registrera medlem           ");
            Console.WriteLine("2 - Visa medlemmar              ");
            Console.WriteLine("3 - Radera medlem               ");
            Console.WriteLine("4 - Redigera info för medlem    ");
            Console.WriteLine("5 - Granska enskild medlem      ");
            Console.WriteLine("                                ");
            Console.WriteLine("Båtar                           ");
            Console.WriteLine("                                ");
            Console.WriteLine("6 - Registrera medlemsbåt       ");
            Console.WriteLine("7 - Radera båt                  ");
            Console.WriteLine("8 - Redigera info för båt       ");
            Console.WriteLine("                                ");
            Console.WriteLine("================================");
            Console.WriteLine("                                ");
        }

        public enum MenuSelection 
        {
            Quit            = 0,            
            //Member Region Menu
            MemberCreate    = 1,
            MemberRead      = 5,
            MemberReadAll   = 2,
            MemberUpdate    = 4,
            MemberDelete    = 3,
            //Boat Region Menu
            BoatCreate      = 6,
            BoatUpdate      = 8,
            BoatDelete      = 7
        }

        public MenuSelection clientDidChoose() 
        {
            
            
            int selected = int.Parse(Console.ReadLine());

            return (MenuSelection)selected;
        }

    }
}
