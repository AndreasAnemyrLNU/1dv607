using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.C
{
    class MemberRead : BaseController
    {
        public M.BoatCatalog BoatCatalog { get; set; }

        public M.Member Member { get; set; }

        public M.MemberCatalog MemberCatalog { get; set; }

        public V.Index Menu { get; set; }

        private V.MemberRead VMemberRead { get; set; }

        public MemberRead(M.MemberCatalog memberCatalog, V.Index menu, M.BoatCatalog boatCatalog)
        {
            BoatCatalog = boatCatalog;
            MemberCatalog = memberCatalog;
            Menu = menu;

            // View Required for Interaction with Client
            VMemberRead = new V.MemberRead();
        }

        public M.Member ReadMemberFromMemberCatalog()
        {
            Member = null;
            Menu.selectedInMenuMemberRead = V.MenuMemberRead.StatelessForNow;

            while (Member == null || Menu.selectedInMenuMemberRead == V.MenuMemberRead.Continue)
            {
                string persNr = VMemberRead.AskClientAboutPersonalNumber();
                Member = MemberCatalog.getReferenceOfMemberInMemberCatalog(persNr);

                // Has Member any boats?
                List<M.Boat> boats = BoatCatalog.getReferencesOfMemberBoatsInBoatCatalog(Member);
                int nrOfBoatsOwnedByMember = boats.Count;

                VMemberRead.ShowMember(Member, "Member's Specific Info\n", nrOfBoatsOwnedByMember);
               
                if (Member == null)
                {
                    VMemberRead.NotExistingMember();
                }

                Menu.RenderingMenuMemberReadQuitOrContinueAndRememberClientsSelection();

                if (Menu.selectedInMenuMemberRead == V.MenuMemberRead.AddBoatToMember) 
                {
                    Menu.SelectedInMenuMain = V.IndexMenu.BoatCreate;
                    Menu.quitTestSelectionAlreadySetByAChildController = true;
                    break;
                }

                if (Menu.selectedInMenuMemberRead == V.MenuMemberRead.Quit)
                {
                    break;
                }
            }
            return Member;
        }
    }
}
