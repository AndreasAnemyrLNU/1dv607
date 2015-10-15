using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.C
{
    class MemberReadAll : BaseController
    {
        public V.Index Menu { get; set; }

        public MemberReadAll(V.Index menu) 
        {
            Menu = menu;
        }

        public void getCompactMemberCatalog(M.MemberCatalog memberCatalog, V.MemberCatalog view)
        {
            memberCatalog.Reset();
            view.outputCompactMemberCatalog(memberCatalog);
            Menu.RenderingMenuShowMembersQuitOrContinueAndRememberClientsSelection();
            if (Menu.SelectedInMenuMember == V.MenuMemberReadAll.Continue)
            {
                Menu.RenderingMenuShowMembersAndRememberClientsSelection();
            }
        }

        public void getVerboseMemberCatalog(M.MemberCatalog memberCatalog, M.BoatCatalog boatCatalog ,V.MemberCatalog view) 
        {
            view.outputVerboseMemberCatalog(memberCatalog, boatCatalog);
        }
    }
}
