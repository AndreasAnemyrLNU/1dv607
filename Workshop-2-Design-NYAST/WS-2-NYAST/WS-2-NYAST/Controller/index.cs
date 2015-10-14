using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Controller
{
    class index
    {
        // Test the current menu to update and so...
        private View.BaseMenu Menu { get; set; }

        // Start Region :: Menu stuff
        // Lists...
        private List<View.IMenu> IMenus     { get; set; }
        private List<Model.Menu> ModelMenus { get; set; }
        // Lists...   
        View.MenuMain   ViewMenuMain    { get; set; }
        View.MenuMember ViewMenuMember  { get; set; }
        View.MenuBoat   ViewMenuBoat    { get; set; }
        View.MenuQuit   ViewMenuQuit    { get; set; }
        View.MenuSave ViewMenuSave      { get; set; }

        Model.Menu MenuBoat             { get; set; }
        Model.Menu MenuMain             { get; set; }
        Model.Menu MenuMember           { get; set; }
        Model.Menu MenuQuit             { get; set; }
        Model.Menu MenuSave              { get; set; } 


        // End Region   :: Menu stuff

        // Start Region :: Catalogs/Register - cached. Persistent saving from these..
        private Model.MemberCatalog MemberCatalog { get; set; }
        // End Regions  :: Catalogs/Register - cached. Persistent svaing from these...

        private View.ConsoleIn Cin { get; set; }
        private View.ConsoleOut Cout { get; set;}
        

        public index()  
        {
            Cin = new View.ConsoleIn();
            Cout = new View.ConsoleOut();
            MemberCatalog = new Model.MemberCatalog();
            // To create the list in the class. Nothing more...
            MemberCatalog.Create();
        }
         
        // New menus must be added here
        private void PrepareMenus()
        {
            //TODO Replace with loop over all existing menus
            IMenus = new List<View.IMenu>();
            ModelMenus = new List<Model.Menu>();
            MenuBoat    = new Model.Menu();
            // Default Setup!
            MenuMain    = new Model.Menu(true);
            MenuMain.State = Model.Menu.MainMenu.MenuMain; 
            MenuMember  = new Model.Menu();
            MenuQuit    = new Model.Menu();
            MenuSave    = new Model.Menu();
            
            // For easier resetting from index.
            ViewMenuMain    = new View.MenuMain     (Cin, Cout, MenuMain);
            ViewMenuMember  = new View.MenuMember   (Cin, Cout, MenuMember);
            ViewMenuBoat    = new View.MenuBoat     (Cin, Cout, MenuBoat);
            ViewMenuQuit    = new View.MenuQuit     (Cin, Cout, MenuBoat);
            ViewMenuSave    = new View.MenuSave     (Cin, Cout, MenuBoat);

            IMenus.Add(ViewMenuBoat);
            IMenus.Add(ViewMenuMain);
            IMenus.Add(ViewMenuMember);
            IMenus.Add(ViewMenuQuit);
            IMenus.Add(ViewMenuSave);
        }

        private void DoMenu() 
        {

            while (ViewMenuMain.ModelMenu.State != Model.Menu.MainMenu.StateLess)
            {
                switch (ViewMenuMain.ModelMenu.State)
                {
                    // MenuMain
                    case WS_2_NYAST.Model.Menu.MainMenu.MenuMain:
                        Menu = ViewMenuMain;
                        Menu.ShowIt(Menu, IMenus);
                        // Activates underlaying...
                        int input = Cin.readKeyToInt();
                        ViewMenuMain.ModelMenu.State = (Model.Menu.MainMenu)input;
                        // Activate rigth menuModel for next iteration                             
                        break;
                    // MenuMember
                    
                    case WS_2_NYAST.Model.Menu.MainMenu.MenuMember:

                       
                        if (ViewMenuMember.State == View.MenuMember.Menu.StateLess)
                        {
                            Menu = ViewMenuMember;
                            Menu.ShowIt(Menu, IMenus);
                            ViewMenuMember.State = (View.MenuMember.Menu)Cin.readKeyToInt();
                        }
                        else
                        {
                            // Cretae Controller for member
                            var ControllerMember = new Controller.member(Cin, Cout, ViewMenuMember, MemberCatalog);

                            switch (ViewMenuMember.State)
                            {
                                case WS_2_NYAST.View.MenuMember.Menu.StateLess:
                                    ControllerMember.Stateless();
                                    break;
                                case WS_2_NYAST.View.MenuMember.Menu.Create:
                                    ControllerMember.Create(MemberCatalog);
                                    break;
                                case WS_2_NYAST.View.MenuMember.Menu.Read:
                                    ControllerMember.Read(true);
                                    break;
                                case WS_2_NYAST.View.MenuMember.Menu.Update:
                                    ControllerMember.Update();
                                    break;
                                case WS_2_NYAST.View.MenuMember.Menu.Delete:
                                    ControllerMember.Delete();
                                    break;
                                case WS_2_NYAST.View.MenuMember.Menu.Save:
                                    ControllerMember.Save();
                                    break;
                                case WS_2_NYAST.View.MenuMember.Menu.Quit:
                                    ControllerMember.Quit();
                                    ViewMenuMain.ModelMenu.State = Model.Menu.MainMenu.MenuMain;
                                    ViewMenuMain.ModelMenu.IsActive = true;
                                    Menu = ViewMenuMain;
                                    break;
                            }
                        }
                        break;
                    
                    case WS_2_NYAST.Model.Menu.MainMenu.MenuBoat:
                        Menu = ViewMenuBoat;
                        Menu.ShowIt(Menu, IMenus);

                        if (ViewMenuBoat.ModelMenu.State == View.MenuBoat.Menu.StateLess)
                        {
                            Menu = ViewMenuBoat;
                            Menu.ShowIt(Menu, IMenus);
                            ViewMenuBoat.State = (View.MenuBoat.Menu)Cin.readKeyToInt();
                        }
                        else
                        {
                            // Cretae Controller for member
                            var ControllerMember = new Controller.Boat(Cin, Cout, ViewMenuBoat, MemberCatalog);

                            switch (ViewMenuBoat.State)
                            {
                                case WS_2_NYAST.View.MenuBoat.Menu.StateLess:
                                    ControllerMember.Stateless();
                                    break;
                                case WS_2_NYAST.View.MenuBoat.Menu.Create:
                                    ControllerMember.Create(MemberCatalog);
                                    break;
                                case WS_2_NYAST.View.MenuBoat.Menu.Read:
                                    ControllerMember.Read(true);
                                    break;
                                case WS_2_NYAST.View.MenuBoat.Menu.Update:
                                    ControllerMember.Update();
                                    break;
                                case WS_2_NYAST.View.MenuBoat.Menu.Delete:
                                    ControllerMember.Delete();
                                    break;
                                case WS_2_NYAST.View.MenuBoat.Menu.Save:
                                    ControllerMember.Save();
                                    break;
                                case WS_2_NYAST.View.MenuBoat.Menu.Quit:
                                    ControllerMember.Quit();
                                    ViewMenuMain.ModelMenu.State = Model.Menu.MainMenu.MenuMain;
                                    ViewMenuMain.ModelMenu.IsActive = true;
                                    Menu = ViewMenuMain;
                                    break;
                            }
                        }                        
                        
                        
                        break;
                   
                    case WS_2_NYAST.Model.Menu.MainMenu.MenuSave:
                        Menu = ViewMenuSave;
                        Menu.ShowIt(Menu, IMenus);
                        throw new NotImplementedException("MenuSave");
                        Menu = Menu as View.MenuSave;
                        break;
                    
                    case WS_2_NYAST.Model.Menu.MainMenu.MenuQuit:
                        Menu = ViewMenuQuit;
                        Menu.ShowIt(Menu, IMenus);
                        var ControllerQuit = new Controller.quit();
                        ControllerQuit.JustDoIt(Cin, Cout, 5000, ViewMenuMain.ModelMenu);
                        break;
                    
                    default:
                        break;
                }
            }     
        }

        public void Do()
        {
            PrepareMenus();
            
            DoMenu();

        }
    }
}

