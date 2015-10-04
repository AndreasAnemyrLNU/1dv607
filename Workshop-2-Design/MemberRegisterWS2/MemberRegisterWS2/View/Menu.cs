using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum MenuDeleteMember 
{
    Quit = 0,
    Continue = 1,
    StatelessForNow
}

enum MenuMain
{
    Quit = 0,
    //Member Region Menu
    MemberCreate = 1,
    MemberRead = 5,
    MemberReadAll = 2,
    MemberUpdate = 4,
    MemberDelete = 3,
    //Boat Region Menu
    BoatCreate = 6,
    BoatUpdate = 8,
    BoatDelete = 7
}

enum MenuMemberRead
{
    Quit = 0,
    Continue = 1,
    MemberRead = 2,
    StatelessForNow
}

enum MenuMemberReadAll
{
    Quit = 0,
    Continue = 1,
    MemberReadAllCompact = 2,
    MemberReadAllVerbos = 3,
    StatelessForNow
}

enum MenuUpdateMember
{
    Quit = 0,
    Continue = 1,
    StatelessForNow
}

enum MenuType
{
    Main,
    Member
}


namespace MemberRegisterWS2.V
{
    class Menu : baseMember
    {
        public MenuMain SelectedInMenuMain { get; set; }

        public MenuMemberReadAll SelectedInMenuMember { get; set; }

        public MenuDeleteMember selectedInMenuDeleteMember { get; set; }

        public MenuUpdateMember selectedInMenuUpdateMember { get; set; }

        public MenuMemberRead selectedInMenuMemberRead { get; set; } 

        public int Selected { get; set; }

        private void MenuMain()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("       B å t k l u b b en       ");
            Console.WriteLine("================================");
            Console.WriteLine("                     - Huvudmeny");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Sektion Medlemmar               ");
            Console.ResetColor();
            Console.WriteLine("                                ");
            Console.WriteLine("# 1 - Registrera medlem           ");
            Console.WriteLine("# 2 - Visa medlemmar              ");
            Console.WriteLine("# 3 - Radera medlem               ");
            Console.WriteLine("# 4 - Redigera info för medlem    ");
            Console.WriteLine("# 5 - Granska enskild medlem      ");
            Console.WriteLine("                                ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Sektion Båtar                   ");
            Console.ResetColor();
            Console.WriteLine("                                ");
            Console.WriteLine("# 6 - Registrera medlemsbåt       ");
            Console.WriteLine("# 7 - Radera båt                  ");
            Console.WriteLine("# 8 - Redigera info för båt       ");
            Console.WriteLine("                                ");
            Console.WriteLine("================================");
            Console.WriteLine("================================");
        }

        public void MenuShowMembers()
        {
            //Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("                - Visa Medlemmar");
            Console.WriteLine("================================");
            Console.WriteLine("                                ");
            Console.WriteLine("# 0 - Avbryt                    ");
            Console.WriteLine("# 2 - Lista Kompakt  (Medlemmar)");
            Console.WriteLine("# 3 - Lista Utförlig (Medlemmar)");
            Console.WriteLine("                                ");
            Console.WriteLine("================================");
            Console.WriteLine("================================");
        }

        public void MenuShowMembersQuitOrContinue()
        {
            Console.WriteLine("                                ");
            Console.WriteLine("================================");
            Console.WriteLine("========= - Vad vill du göra nu?");
            Console.WriteLine("                                ");
            Console.WriteLine("# 0 - Avsluta                   ");
            Console.WriteLine("# 1 - Visa medlemmar igen       ");
            Console.WriteLine("                                ");
            Console.WriteLine("================================");
            Console.WriteLine("================================");
        }

        public void MenuShowDeleteMemberQuitOrContinue()
        {
            Console.WriteLine("                                ");
            Console.WriteLine("================================");
            Console.WriteLine("========= - Vad vill du göra nu?");
            Console.WriteLine("                                ");
            Console.WriteLine("# 0 - Avsluta                   ");
            Console.WriteLine("# 1 - Försöka radera på nytt    ");
            Console.WriteLine("                                ");
            Console.WriteLine("================================");
            Console.WriteLine("================================");
        }

        public void MenuShowUpdateMemberQuitOrContinue()
        {
            Console.WriteLine("                                ");
            Console.WriteLine("================================");
            Console.WriteLine("========= - Vad vill du göra nu?");
            Console.WriteLine("                                ");
            Console.WriteLine("# 0 - Avsluta                   ");
            Console.WriteLine("# 1 - Försöka uppdatera på nytt ");
            Console.WriteLine("                                ");
            Console.WriteLine("================================");
            Console.WriteLine("================================");
        }

        public void ShowMenuMemberReadQuitOrContinue()
        {
            Console.WriteLine("                                ");
            Console.WriteLine("================================");
            Console.WriteLine("======== - What do you wanna do?");
            Console.WriteLine("                                ");
            Console.WriteLine("# 0 - End                       ");
            Console.WriteLine("# 1 - Read New Member...        ");
            Console.WriteLine("                                ");
            Console.WriteLine("================================");
            Console.WriteLine("================================");
        }

        public void RenderingMenuShowMembersQuitOrContinueAndRememberClientsSelection()
        {
            //Console.Clear();
            MenuShowMembersQuitOrContinue();
            Selected = int.Parse(AskForInput(AskForInt));
            SelectedInMenuMember = (MenuMemberReadAll)Selected;
        }

        public void RenderingMenuDeleteMemberQuitOrContinueAndRememberClientsSelection()
        {
            //Console.Clear();
            MenuShowDeleteMemberQuitOrContinue();
            Selected = int.Parse(AskForInput(AskForInt));
            selectedInMenuDeleteMember = (MenuDeleteMember)Selected;
        }

        public void RenderingMenuUpdateMemberQuitOrContinueAndRememberClientsSelection()
        {
            MenuShowUpdateMemberQuitOrContinue();
            Selected = int.Parse(AskForInput(AskForInt));
            selectedInMenuUpdateMember = (MenuUpdateMember)Selected;
        }

        public void RenderingMenuMainAndRememberClientsSelection()
        {
            MenuMain();
            Selected = int.Parse(AskForInput(AskForInt));
            SelectedInMenuMain = (MenuMain)Selected;
        }

        public void RenderingMenuShowMembersAndRememberClientsSelection()
        {
            //Inget command att svarapå
            SelectedInMenuMember = MenuMemberReadAll.StatelessForNow;

            MenuShowMembers(); //Ut med menyn ingen retur eller nåt sånt
            
            while (SelectedInMenuMember == MenuMemberReadAll.StatelessForNow)
            {
                try
                {
                    Selected = int.Parse(AskForInput(AskForInt));

                    if (Selected < 2 || Selected > 3)
                    {
                        if(Selected != 0)
                        {
                            throw new Exception("Du skrev felaktig siffra. Försök igen!");
                        }
                    }

                    SelectedInMenuMember = (MenuMemberReadAll)Selected;                                        
                }
                catch (Exception)
                {
                    Console.WriteLine("Ange med siffror!");
                }
            }
        }

        public void RenderingMenuMemberReadQuitOrContinueAndRememberClientsSelection()
        {
            ShowMenuMemberReadQuitOrContinue();
            Selected = int.Parse(AskForInput(AskForInt));
            selectedInMenuMemberRead = (MenuMemberRead)Selected;
        }
    }
}
