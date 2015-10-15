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
        public View.BaseMenu Menu { get; set; }

        // Start Region :: Menu stuff
        // Lists...
        public List<View.IMenu> IMenus     { get; set; }
        public List<Model.Menu> ModelMenus { get; set; }
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

        WS_2_NYAST.MODEL.ToFileDAL FileDal;

        // Start Region :: Catalogs/Register - cached. Persistent saving from these..
    
        public Model.MemberCatalog MemberCatalog { get; set; }
        public Model.BoatCatalog BoatCatalog { get; set; }
        // End Regions  :: Catalogs/Register - cached. Persistent svaing from these...

        public View.ConsoleIn Cin { get; set; }
        public View.ConsoleOut Cout { get; set;}
        

        public index()  
        {
            Cin = new View.ConsoleIn();
            Cout = new View.ConsoleOut();
            MemberCatalog = new Model.MemberCatalog();
            // To create the list so it exists...
            MemberCatalog.Create();
            BoatCatalog = new Model.BoatCatalog();
            BoatCatalog.Create();
            // To create the list so it exists...

            // Persistent storing...
            FileDal = new WS_2_NYAST.MODEL.ToFileDAL();
        }
         
        // New menus must be added here
        public void PrepareMenus()
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

        public void DoMenu() 
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

                        // Nothing has been choosen from menu...
                        if (ViewMenuMember.State == View.MenuMember.Menu.StateLess)
                        {
                            Menu = ViewMenuMember;
                            Menu.ShowIt(Menu, IMenus);
                            ViewMenuMember.State = (View.MenuMember.Menu)Cin.readKeyToInt();
                        }
                        else
                        {
                            // Cretae Controller for member
                            var ControllerMember = new Controller.member(Cin, Cout, ViewMenuMember, MemberCatalog, BoatCatalog);

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
                                case WS_2_NYAST.View.MenuMember.Menu.Compact:
                                    ControllerMember.Compact();
                                    break;
                                case WS_2_NYAST.View.MenuMember.Menu.Verbose:
                                    ControllerMember.Verbose();
                                    break;
                                case WS_2_NYAST.View.MenuMember.Menu.Save:
                                    ControllerMember.Save();
                                    break;
                                case WS_2_NYAST.View.MenuMember.Menu.Quit:
                                    ControllerMember.Quit();
                                    ViewMenuMain.ModelMenu.State = Model.Menu.MainMenu.MenuMain;
                                    ViewMenuMain.ModelMenu.IsActive = true;
                                    break;
                            }
                        }
                        break;
                    
                    case WS_2_NYAST.Model.Menu.MainMenu.MenuBoat:

                        if (ViewMenuBoat.State == View.MenuBoat.Menu.StateLess)
                        {
                            Menu = ViewMenuBoat;
                            Menu.ShowIt(Menu, IMenus);
                            ViewMenuBoat.State = (View.MenuBoat.Menu)Cin.readKeyToInt();
                        }
                        else
                        {
                            // Cretae Controller for member
                            var ControllerBoat = new Controller.Boat(Cin, Cout, ViewMenuBoat, MemberCatalog, BoatCatalog);

                            switch (ViewMenuBoat.State)
                            {
                                case WS_2_NYAST.View.MenuBoat.Menu.StateLess:
                                    ControllerBoat.Stateless();
                                    break;
                                case WS_2_NYAST.View.MenuBoat.Menu.Create:
                                    ControllerBoat.Create(BoatCatalog);
                                    break;
                                case WS_2_NYAST.View.MenuBoat.Menu.Read:
                                    ControllerBoat.Read(true);
                                    break;
                                case WS_2_NYAST.View.MenuBoat.Menu.Update:
                                    ControllerBoat.Update();
                                    break;
                                case WS_2_NYAST.View.MenuBoat.Menu.Delete:
                                    ControllerBoat.Delete();
                                    break;
                                case WS_2_NYAST.View.MenuBoat.Menu.Save:
                                    ControllerBoat.Save();
                                    break;
                                case WS_2_NYAST.View.MenuBoat.Menu.Quit:
                                    ControllerBoat.Quit();
                                    ViewMenuMain.ModelMenu.State = Model.Menu.MainMenu.MenuMain;
                                    ViewMenuMain.ModelMenu.IsActive = true;
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


            string fileBoatCatalog = string.Format("{0}/BoatCatalog.txt", AppDomain.CurrentDomain.BaseDirectory);
            string fileMembersCatalog = string.Format("{0}/MemberCatlog.txt", AppDomain.CurrentDomain.BaseDirectory);

            try 
            {
                BoatCatalog = FileDal.ReadFromXmlFile<Model.BoatCatalog>(fileBoatCatalog);
                MemberCatalog = FileDal.ReadFromXmlFile<Model.MemberCatalog>(fileMembersCatalog);
            }
            catch (Exception e)
            {
                new View.Error(e);
            }
            

            DoMenu();

            FileDal.WriteToXmlFile<Model.BoatCatalog>(fileBoatCatalog, BoatCatalog, false);
            FileDal.WriteToXmlFile<Model.MemberCatalog>(fileMembersCatalog, MemberCatalog, false);


    
        }
    }
}

