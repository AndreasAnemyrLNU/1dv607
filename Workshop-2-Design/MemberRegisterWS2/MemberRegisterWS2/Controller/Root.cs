using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.C
{
    class Root : BaseController
    {
        private M.BoatCatalog BoatCatalog { get; set; }

        private M.MemberCatalog MemberCatalog { get; set; } 
        
        private V.Menu Menu { get; set; }

        //Constructor
        public Root(V.Menu menu)
        {
            Menu = menu;
            MemberCatalog = new M.MemberCatalog();
            BoatCatalog = new M.BoatCatalog();
        }
        
        // This is the root controller. DoApplication() should/could be named doInitApp().
        public void DoApplication()
        {

            //Just in purpose of testing!
            MemberCatalog.addMember(new M.Member("kurt", "Kurtsson", "111111-1111"));
            MemberCatalog.addMember(new M.Member("Pär", "Pärsson",   "222222-2222"));
            MemberCatalog.addMember(new M.Member("Åke", "Åkesson",   "333333-3333"));
            MemberCatalog.addMember(new M.Member("Sven", "Svenssson","444444-4444"));
            MemberCatalog.addMember(new M.Member("Ante", "Antesson", "555555-5555"));

            Menu.RenderingMenuMainAndRememberClientsSelection();

            while (Menu.SelectedInMenuMain != MenuMain.Quit)
            {
                switch (Menu.SelectedInMenuMain)
                {
                    // 3.1.0 Req 1 :: Region Start
                    //                                                                              -----Create a member-----
                    case MenuMain.MemberCreate:
                        var controller = CFactory(CType.MemberCreate) as C.MemberCreate;
                        //Client tries creating new Member
                        var member = controller.DoMemberCreate();
                        //New Member cached in this.memberCatalg
                        MemberCatalog.addMember(member);
                        break;
                    // 3.1.0 Req 1 :: Region End

                    // 3.2.0 Req 2 :: Region Start
                    //                                                                              -----List All members-----
                    case MenuMain.MemberReadAll:
                        var cMemberReadAll = CFactory(CType.MemberReadAll, Menu) as C.MemberReadAll;    
                        //3.2.1 Render Menu for Members        
                        Menu.RenderingMenuShowMembersAndRememberClientsSelection();                        
                        while (Menu.SelectedInMenuMember != MenuMemberReadAll.Quit)
                        {
                            // 3.2.2 Find out client´s selection
                            switch (Menu.SelectedInMenuMember)
                            {
                                case MenuMemberReadAll.MemberReadAllCompact:
                                    // 3.2.3 Client wants to see Compact Listing. Fullfills req 2.1
                                    //                                                                  -----List All members by Compact List-----                                        
                                    cMemberReadAll.getCompactMemberCatalog(MemberCatalog, new V.MemberCatalog());
                                    break;
                                // 3.2.4 Client wants to see Verbose Listing. Fullfills req 2.2
                                //                                                                  -----List All members by Verbose List-----                                        
                                case MenuMemberReadAll.MemberReadAllVerbos:
                                    cMemberReadAll.getVerboseMemberCatalog(MemberCatalog, new V.MemberCatalog());
                                    break;
                            }
                        }
                        break;
                    // 3.2.0 Req 2 :: Region End
                    // 3.3.0 Req 3 :: Region Start
                    //                                                                              -----Delete a member-----
                    case MenuMain.MemberDelete:
                        var cMemberDelete = CFactory(CType.MemberDelete, Menu, MemberCatalog) as C.MemberDelete;
                        M.Member deletedMember = cMemberDelete.deleteMemberFromMemberCatalog();
                        Menu.SelectedInMenuMain = MenuMain.MemberCreate;
                        break;
                    // 3.3.0 Req 3 :: Region End
                    // 3.4.0 Req 4 :: Region Start
                    //                                                                              ------Change a member's information-----
                    case MenuMain.MemberUpdate:
                        var cMemberUpdate = CFactory(CType.MemberUpdate, Menu, MemberCatalog) as C.MemberUpdate;
                        cMemberUpdate.UpdateMemberFromMemberCatalog();
                        break;
                    // 3.4.0 Req 4 :: Region End
                    // 3.5.0 Req 5 :: Region Start
                    //                                                                              ------Look at a specific member's information-----
                    case MenuMain.MemberRead:
                        var cMemberRead = CFactory(CType.MemberRead, Menu, MemberCatalog) as C.MemberRead;
                        cMemberRead.ReadMemberFromMemberCatalog();
                        break;
                    // 3.5.0 Req 5 :: Region End
                    // 3.6.0 Req 6 :: Region Start
                    //                                                                              ------Register a new boat for a member-----
                    case MenuMain.BoatCreate:
                        var cBoatCreate = CFactory(CType.BoatCreate, Menu, MemberCatalog) as C.BoatCreate;
                        M.Boat boat = cBoatCreate.DoBoatCreate();
                        BoatCatalog.addBoat(boat);
                        break;
                    // 3.6.0 Req 6 :: Region End
                    // 3.7.0 Req 7 :: Region Start
                    //                                                                              ------Delete a boat-----
                    case MenuMain.BoatDelete:
                        break;
                    // 3.7.0 Req 7 :: Region End
                    // 3.8.0 Req 8 :: Region Start
                    //                                                                              ------Change a boat's information-----
                    case MenuMain.BoatUpdate:
                        break;
                    // 3.8.0 Req 8 :: Region End
                }
                // New Selection or Quit Application
                Menu.RenderingMenuMainAndRememberClientsSelection();
            }
        }
    }
}
