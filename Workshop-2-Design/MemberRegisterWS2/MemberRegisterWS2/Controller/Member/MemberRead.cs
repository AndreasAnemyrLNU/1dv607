using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.C
{
    class MemberRead : BaseController
    {
        public M.Member Member { get; set; }

        public M.MemberCatalog MemberCatalog { get; set; }

        public V.Menu Menu { get; set; }

        private V.MemberRead VMemberRead { get; set; }

        public MemberRead(M.MemberCatalog memberCatalog, V.Menu menu)
        {
            MemberCatalog = memberCatalog;
            Menu = menu;

            // View Required for Interaction with Client
            VMemberRead = new V.MemberRead();
        }

        public M.Member ReadMemberFromMemberCatalog()
        {
            Member = null;
            Menu.selectedInMenuMemberRead = MenuMemberRead.StatelessForNow;

            while (Member == null || Menu.selectedInMenuMemberRead == MenuMemberRead.Continue)
            {
                string persNr = VMemberRead.AskClientAboutPersonalNumber();
                Member = MemberCatalog.getReferenceOfMemberInMemberCatalog(persNr);

                VMemberRead.ShowMember(Member, "Member's Specific Info\n");
               
                if (Member == null)
                {
                    VMemberRead.NotExistingMember();
                }

                Menu.RenderingMenuMemberReadQuitOrContinueAndRememberClientsSelection();

                if (Menu.selectedInMenuMemberRead == MenuMemberRead.Quit)
                {
                    break;
                }
            }
            return null;
        }
    }
}
