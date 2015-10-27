using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Controller
{
    public class Index
    {
        public View.BaseMenu Menu                   { get; set; }
        private List<View.IMenu> IMenus             { get; set; }
        private List<Model.Menu> ModelMenus         { get; set; }
        // Lists...   
        public View.MenuMain   ViewMenuMain         { get; set; }
        public View.MenuMember ViewMenuMember       { get; set; }
        public View.MenuBoat   ViewMenuBoat         { get; set; }
        public View.MenuQuit   ViewMenuQuit         { get; set; }
        public View.MenuSave ViewMenuSave           { get; set; }
        public Model.Menu MenuBoat                  { get; set; }
        public Model.Menu MenuMain                  { get; set; }
        public Model.Menu MenuMember                { get; set; }
        public Model.Menu MenuQuit                  { get; set; }
        public Model.Menu MenuSave                  { get; set; } 
        public WS_2_NYAST.MODEL.ToFileDAL FileDal;
        public Model.MemberCatalog MemberCatalog    { get; set; }
        public View.ConsoleIn Cin                   { get; set; }
        public View.ConsoleOut Cout                 { get; set;}

        public Index(Controller.Index index = null) 
        {
            if (index == null) 
            {
                Cin             = new View.ConsoleIn();
                Cout            = new View.ConsoleOut();
                MemberCatalog   = new Model.MemberCatalog();     
                MemberCatalog.Create();
                IMenus          = new List<View.IMenu>();
                ModelMenus      = new List<Model.Menu>();
                MenuBoat        = new Model.Menu();
                // Default Setup!
                MenuMain        = new Model.Menu(true);
                MenuMain.State  = Model.Menu.MainMenu.MenuMain;
                MenuMember      = new Model.Menu();
                MenuQuit        = new Model.Menu();
                MenuSave        = new Model.Menu();
                // For easier resetting from index.
                ViewMenuMain    = new View.MenuMain(Cin, Cout, MenuMain);
                ViewMenuMember  = new View.MenuMember(Cin, Cout, MenuMember);
                ViewMenuBoat    = new View.MenuBoat(Cin, Cout, MenuBoat);
                ViewMenuQuit    = new View.MenuQuit(Cin, Cout, MenuBoat);
                ViewMenuSave    = new View.MenuSave(Cin, Cout, MenuBoat);
                IMenus.Add(ViewMenuBoat);
                IMenus.Add(ViewMenuMain);
                IMenus.Add(ViewMenuMember);
                IMenus.Add(ViewMenuQuit);
                IMenus.Add(ViewMenuSave);       
                FileDal = new WS_2_NYAST.MODEL.ToFileDAL();
            }            
            else 
            {
                this.Cin            = index.Cin;
                this.Cout           = index.Cout;
                this.MemberCatalog  = index.MemberCatalog;
                this.IMenus         = index.IMenus;
                this.ModelMenus     = index.ModelMenus;
                this.MenuBoat       = index.MenuBoat;
                this.MenuMain       = index.MenuMain;
                this.MenuMember     = index.MenuMember;
                this.MenuQuit       = index.MenuQuit;
                this.MenuSave       = index.MenuSave;
                this.ViewMenuMain   = index.ViewMenuMain;
                this.ViewMenuMember = index.ViewMenuMember;
                this.ViewMenuBoat   = index.ViewMenuBoat;
                this.ViewMenuQuit   = index.ViewMenuQuit;
                this.ViewMenuSave   = index.ViewMenuSave;
                this.IMenus         = index.IMenus;
                this.FileDal        = index.FileDal;
            }
        }
         
        public void DoMenu() 
        {

            while (ViewMenuMain.ModelMenu.State != Model.Menu.MainMenu.StateLess)
            {
                switch (ViewMenuMain.ModelMenu.State)
                {
                    // MenuMain
                    case WS_2_NYAST.Model.Menu.MainMenu.MenuMain:
                        ViewMenuMain.ShowIt(Menu, IMenus);
                        // Activates underlaying...
                        int input = Cin.readKeyToInt();
                        ViewMenuMain.ModelMenu.State = (Model.Menu.MainMenu)input;
                        break;                    
                    // MenuMember
                    case WS_2_NYAST.Model.Menu.MainMenu.MenuMember:
                        if (ViewMenuMember.State == View.MenuMember.Menu.StateLess)
                        {
                            ViewMenuMember.ShowIt(Menu, IMenus);
                            ViewMenuMember.State = (View.MenuMember.Menu)Cin.readKeyToInt();
                        }
                        else
                        {
                            Controller.Member ControllerMember = new Controller.Member(this);
                            switch (ViewMenuMember.State)
                            {
                                case WS_2_NYAST.View.MenuMember.Menu.Create:
                                    MemberCatalog.AddMember(ControllerMember.Create());
                                    break;
                                case WS_2_NYAST.View.MenuMember.Menu.Read:
                                    ControllerMember.Read();
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
                                case WS_2_NYAST.View.MenuMember.Menu.Verbose:
                                    new View.Listing().Verbose(MemberCatalog, Cout, Cin);
                                    ViewMenuMember.State = View.MenuMember.Menu.StateLess;
                                    break;
                                case WS_2_NYAST.View.MenuMember.Menu.Compact:
                                    new View.Listing().Compact(MemberCatalog, Cout, Cin);
                                    ViewMenuMember.State = View.MenuMember.Menu.StateLess;
                                    break;
                                case WS_2_NYAST.View.MenuMember.Menu.Quit:
                                    ControllerMember.Quit();
                                    ViewMenuMain.ModelMenu.State = Model.Menu.MainMenu.MenuMain;
                                    break;
                            }
                        }
                        break;                    
                    case WS_2_NYAST.Model.Menu.MainMenu.MenuQuit:
                        ViewMenuQuit.ShowIt(Menu, IMenus);
                        var ControllerQuit = new Controller.Quit(this);
                        ControllerQuit.JustDoIt(5000, this);
                        break;
                }
            }     
        }

        public void Do()
        {
            string fileBoatCatalog = string.Format("{0}/BoatCatalog.txt", AppDomain.CurrentDomain.BaseDirectory);
            string fileMembersCatalog = string.Format("{0}/MemberCatlog.txt", AppDomain.CurrentDomain.BaseDirectory);

            try 
            {
                MemberCatalog = FileDal.ReadFromXmlFile<Model.MemberCatalog>(fileMembersCatalog);
            }
            catch (Exception e)
            {
                new View.Error(e);
            }
            

            DoMenu();
            FileDal.WriteToXmlFile<Model.MemberCatalog>(fileMembersCatalog, MemberCatalog, false);    
        }
    }
}

