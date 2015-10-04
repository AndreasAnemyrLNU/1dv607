using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.C
{
    class MemberUpdate : BaseController
    {
        private M.Member Member { get; set; }

        private M.MemberCatalog MemberCatalog { get; set; }

        private V.Menu Menu { get; set; }

        private V.MemberUpdate VMemberUpdate { get; set; }

        public MemberUpdate(M.MemberCatalog memberCatalog, M.Member member, V.Menu menu) 
        {
            Member = member;
            MemberCatalog = memberCatalog;
            Menu = menu;

            // View Required for Interaction with Client
            VMemberUpdate = new V.MemberUpdate();

        }

        public M.Member UpdateMemberFromMemberCatalog()
        {
            Member = null;
            Menu.selectedInMenuUpdateMember = MenuUpdateMember.StatelessForNow;

            while (Member == null)
            {
                string persNr = VMemberUpdate.AskClientAboutPersonalNumber();
                Member = MemberCatalog.getReferenceOfMemberInMemberCatalog(persNr);

                VMemberUpdate.ShowMember(Member, "Do you really wanna edit ?\n");
                if (VMemberUpdate.ShowExistingValueAndAskClientForUpdate("Firstname", Member.FirstName)) 
                {
                    Member.FirstName = VMemberUpdate.AskClientAboutFirstName();
                }

                VMemberUpdate.ShowMember(Member, "Do you really wanna edit ?\n");
                if (VMemberUpdate.ShowExistingValueAndAskClientForUpdate("Lastname", Member.LastName)) 
                {
                    Member.LastName = VMemberUpdate.AskClientAboutLastName();
                }

                VMemberUpdate.ShowMember(Member, "Do you really wanna edit ?\n");
                if (VMemberUpdate.ShowExistingValueAndAskClientForUpdate("Personal Number", Member.PersNr)) 
                {
                    Member.PersNr = VMemberUpdate.AskClientAboutPersonalNumber();
                }

                if (Member == null)
                {
                    VMemberUpdate.NotExistingMember();
                    Menu.RenderingMenuUpdateMemberQuitOrContinueAndRememberClientsSelection();
                }
                if (Menu.selectedInMenuUpdateMember == MenuUpdateMember.Quit)
                {
                    break;
                }
            }
            return null;
            //return MemberCatalog.deleteMemberInMemberCatalog(Member);
        }
    }
}
