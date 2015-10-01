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
            Console.WriteLine("================================");
            Console.WriteLine("           Båtklubben           ");
            Console.WriteLine("                                ");
            Console.WriteLine("================================");
            Console.WriteLine("                                ");
            Console.WriteLine("Medelemmar                      ");
            Console.WriteLine("                                ");
            Console.WriteLine("Välj (siffra)                   ");
            Console.WriteLine("                                ");
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
            Console.WriteLine("================================");
        }

        public void RenderMemberMenu() 
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("Välj (siffra)...................");
            Console.WriteLine("================================");
            Console.WriteLine("                                ");
            Console.WriteLine("1 - Lista Kompakt  (Medlemmar)  ");
            Console.WriteLine("2 - Lista Utförlig (Medlemmar)  ");
            Console.WriteLine("                                ");
            Console.WriteLine("================================");
            Console.WriteLine("================================");

        }

        public enum MenuMain 
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

        public enum MenuMember 
        {
            Quit                    = 0,
            MemberReadAllCompact    = 1,
            MemberReadAllVerbos     = 2
        }

        public enum MenuType
        {
            Main,
            Member
        }

        public MenuMain ClientsMenuMainSelection() 
        {
            int selected = int.Parse(Console.ReadLine());
            return (MenuMain)selected;
        }

        public MenuMember ClientsMenuMemberSelection()
        {
            int selected = int.Parse(Console.ReadLine());
            return (MenuMember)selected;
        }

    }
}
