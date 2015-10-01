using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.Controller
{
    class Root : baseController
    {
        private Model.MemberCatalog MemberCatalog { get; set; } 
        
        private View.Menu Menu { get; set; }

        //Constructor
        public Root(View.Menu menu)
        {
            Menu = menu;
            MemberCatalog = new Model.MemberCatalog();
        }
        // This is the root controller. DoApplication() should/could be named doInitApp().
        public void DoApplication()
        {

            //Just in purpose of testing!
            MemberCatalog.addMember(new Model.Member(   "kurt" , "Kurtsson"     ));
            MemberCatalog.addMember(new Model.Member(   "Pär"  , "Pärsson"      ));
            MemberCatalog.addMember(new Model.Member(   "Åke"  , "Åkesson"      ));
            MemberCatalog.addMember(new Model.Member(   "Sven" , "Svenssson"    ));
            MemberCatalog.addMember(new Model.Member(   "Ante" , "Antesson"     ));
            
            
            // 1.0.0 Render Menu for Client
            Menu.Welcome();
        
            // 2.0.0 Wait for Selection by user :: Region Start
            do
            {
                // 3.0.0 Find out client´s selection :: Region Start
                switch (Menu.ClientsMenuMainSelection()) 
                {
                    // 3.1.0 Req 1 :: Region Start
                    //                                                                              -----Create a member-----
                    case View.Menu.MenuMain.MemberCreate:
                        var controller = base.ControllerFactory("MemberCreate") as Controller.MemberCreate;
                        //Client tries creating new Member
                        var member = controller.DoMemberCreate();
                        //New Member cached in this.memberCatalg
                        MemberCatalog.addMember(member);
                    break;
                    // 3.1.0 Req 1 :: Region End
                        
                    // 3.2.0 Req 2 :: Region Start
                    //                                                                              -----List All members-----
                    case View.Menu.MenuMain.MemberReadAll:
                        //3.2.1 Render Menu for Members
                        Menu.RenderMemberMenu();
                        do
                        {
                            var memberReadAllController = base.ControllerFactory("MemberReadAll") as Controller.MemberReadAll;
                            // 3.2.2 Find out client´s selection
                            switch (Menu.ClientsMenuMemberSelection())
                            { 
                                case View.Menu.MenuMember.MemberReadAllCompact:
                                // 3.2.3 Client wants to see Compact Listing. Fullfills req 2.1
                                //                                                                  -----List All members by Compact List-----                                        
                                memberReadAllController.getCompactMemberCatalog(MemberCatalog, new View.MemberCatalog());
                                break;
                                // 3.2.4 Client wants to see Verbose Listing. Fullfills req 2.2
                                //                                                                  -----List All members by Compact List-----                                        
                                case View.Menu.MenuMember.MemberReadAllVerbos:
                                    memberReadAllController.getVerboseMemberCatalog(MemberCatalog, new View.MemberCatalog());
                                break;
                            }
                        //Client can end with menu with (enum) Quit!
                        } while (Menu.ClientsMenuMemberSelection() != View.Menu.MenuMember.Quit);
                    break;                    
                    // 3.2.0 Req 2 :: Region End
                    // 3.3.0 Req 3 :: Region Start
                    //                                                                              -----Delete a member-----
                    case View.Menu.MenuMain.MemberDelete:
                    break;
                    // 3.3.0 Req 3 :: Region End
                    // 3.4.0 Req 4 :: Region Start
                    //                                                                              ------Change a member's information-----
                    case View.Menu.MenuMain.MemberUpdate:
                    break;
                    // 3.4.0 Req 4 :: Region End
                    // 3.5.0 Req 5 :: Region Start
                    //                                                                              ------Look at a specific member's information-----
                    case View.Menu.MenuMain.MemberRead:
                    break;
                    // 3.5.0 Req 5 :: Region End
                    // 3.6.0 Req 6 :: Region Start
                    //                                                                              ------Register a new boat for a member-----
                    case View.Menu.MenuMain.BoatCreate:
                    break;
                    // 3.6.0 Req 6 :: Region End
                    // 3.7.0 Req 7 :: Region Start
                    //                                                                              ------Delete a boat-----
                    case View.Menu.MenuMain.BoatDelete:
                    break;
                    // 3.7.0 Req 7 :: Region End
                    // 3.8.0 Req 8 :: Region Start
                    //                                                                              ------Change a boat's information-----
                    case View.Menu.MenuMain.BoatUpdate:
                    break;
                    // 3.8.0 Req 8 :: Region End
                }
                // 3.0.0 Find out client´s selection :: Region End
            }
            //Client can end menu with (enum) Quit!
            while (Menu.ClientsMenuMainSelection() != View.Menu.MenuMain.Quit);
            // 2.0.0 Wait for Selection by user :: Region End
        }
        
    }
}
