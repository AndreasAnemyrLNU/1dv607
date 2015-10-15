using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.C
{
    class IndexController : BaseController
    {
        private M.Boat Boat { get; set; }

        private M.BoatCatalog BoatCatalog { get; set; }

        private M.MemberCatalog MemberCatalog { get; set; } 
        
        private V.Index Menu { get; set; }

        private V.CommonQuestions CommonQuestions { get; set; }

        public M.Member Member { get; set; }

        //Constructor
        public IndexController(V.Index menu)
        {
            Menu = menu;
            CommonQuestions = new V.CommonQuestions();
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

            while (Menu.SelectedInMenuMain != V.IndexMenu.Quit)
            {
                // Start Region :: Important preconfiguration for mainmenu for each iteration. Resetting!
                Menu.quitTestSelectionAlreadySetByAChildController = false;
                // End Region :::: Important preconfiguration for mainmenu for each iteration. Resetting!
                
                switch (Menu.SelectedInMenuMain)
                {
                    // 3.1.0 Req 1 :: Region Start
                    //                                                                              -----Create a member-----
                    case V.IndexMenu.MemberCreate:
                        var controller = CFactory(CType.MemberCreate) as C.MemberCreate;
                        //Client tries creating new Member
                        var member = controller.DoMemberCreate();
                        //New Member cached in this.memberCatalg
                        MemberCatalog.addMember(member);
                        break;
                    // 3.1.0 Req 1 :: Region End

                    // 3.2.0 Req 2 :: Region Start
                    //                                                                              -----List All members-----
                    case V.IndexMenu.MemberReadAll:
                        var cMemberReadAll = CFactory(CType.MemberReadAll, Menu) as C.MemberReadAll;    
                        //3.2.1 Render Menu for Members        
                        Menu.RenderingMenuShowMembersAndRememberClientsSelection();                        
                        while (Menu.SelectedInMenuMember != V.MenuMemberReadAll.Quit)
                        {
                            // 3.2.2 Find out client´s selection
                            switch (Menu.SelectedInMenuMember)
                            {
                                case V.MenuMemberReadAll.MemberReadAllCompact:
                                    // 3.2.3 Client wants to see Compact Listing. Fullfills req 2.1
                                    //                                                                  -----List All members by Compact List-----                                        
                                    cMemberReadAll.getCompactMemberCatalog(MemberCatalog, new V.MemberCatalog());
                                    break;
                                // 3.2.4 Client wants to see Verbose Listing. Fullfills req 2.2
                                //                                                                  -----List All members by Verbose List-----                                        
                                case V.MenuMemberReadAll.MemberReadAllVerbose:
                                    cMemberReadAll.getVerboseMemberCatalog(MemberCatalog, BoatCatalog, new V.MemberCatalog());
                                    break;
                            }
                        }
                        break;
                    // 3.2.0 Req 2 :: Region End
                    // 3.3.0 Req 3 :: Region Start
                    //                                                                              -----Delete a member-----
                    case V.IndexMenu.MemberDelete:
                        var cMemberDelete = CFactory(CType.MemberDelete, Menu, MemberCatalog) as C.MemberDelete;
                        M.Member deletedMember = cMemberDelete.deleteMemberFromMemberCatalog();
                        Menu.SelectedInMenuMain = V.IndexMenu.MemberCreate;
                        break;
                    // 3.3.0 Req 3 :: Region End
                    // 3.4.0 Req 4 :: Region Start
                    //                                                                              ------Change a member's information-----
                    case V.IndexMenu.MemberUpdate:
                        var cMemberUpdate = CFactory(CType.MemberUpdate, Menu, MemberCatalog) as C.MemberUpdate;
                        cMemberUpdate.UpdateMemberFromMemberCatalog();
                        break;
                    // 3.4.0 Req 4 :: Region End
                    // 3.5.0 Req 5 :: Region Start
                    //                                                                              ------Look at a specific member's information-----
                    case V.IndexMenu.MemberRead:
                        var cMemberRead = CFactory(CType.MemberRead, Menu, MemberCatalog, null, BoatCatalog) as C.MemberRead;
                        Member = cMemberRead.ReadMemberFromMemberCatalog();
                        break;
                    // 3.5.0 Req 5 :: Region End
                    // 3.6.0 Req 6 :: Region Start
                    //                                                                              ------Register a new boat for a member-----
                    case V.IndexMenu.BoatCreate:
                        var cBoatCreate = CFactory(CType.BoatCreate, Menu, MemberCatalog) as C.BoatCreate;
                        Boat = cBoatCreate.DoBoatCreate(Member);
                        BoatCatalog.addBoat(Boat);
                        break;
                    // 3.6.0 Req 6 :: Region End
                    // 3.7.0 Req 7 :: Region Start
                    //                                                                              ------Delete a boat-----
                    case V.IndexMenu.BoatDelete:
                        var cBoatDelete = CFactory(CType.BoatDelete, Menu, MemberCatalog, null, BoatCatalog) as C.BoatDelete;       
                        var boatsToBeDeleted = cBoatDelete.DoFetchBoatReferencesInBoatCatalg();
                        foreach(M.Boat boat in boatsToBeDeleted)
                        {
                            BoatCatalog.deleteBoatInBoatCatalog(Boat);
                        }
                        break;
                    // 3.7.0 Req 7 :: Region End
                    // 3.8.0 Req 8 :: Region Start
                    //                                                                              ------Change a boat's information-----
                    case V.IndexMenu.BoatUpdate:
                        break;
                    // 3.8.0 Req 8 :: Region End
                }
                // New Selection or Quit Application or skip test!
                if (Menu.quitTestSelectionAlreadySetByAChildController != true) 
                {
                    Menu.RenderingMenuMainAndRememberClientsSelection();                
                }
            }
        }
    }
}
