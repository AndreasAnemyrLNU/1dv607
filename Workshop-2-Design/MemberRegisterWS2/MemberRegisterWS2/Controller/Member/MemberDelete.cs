﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.C
{
    class MemberDelete : BaseController
    {
        M.MemberCatalog MemberCatalog { get; set; }

        M.Member Member { get; set; }

        V.Index Menu { get; set; }

        V.MemberDelete VMemberDelete { get; set; }

        public MemberDelete(M.MemberCatalog memberCatalog, V.Index menu)
        {
            // Model Required
            MemberCatalog = memberCatalog;

            // Needs interaction with menu if no member found
            Menu = menu;

            // View Required for Interaction with Client
            VMemberDelete = new V.MemberDelete();
        }

        public M.Member deleteMemberFromMemberCatalog()
        {
            Member = null;
            Menu.selectedInMenuDeleteMember = V.MenuMemberDelete.StatelessForNow;

            while (Member == null)
            {
                string persNr = VMemberDelete.AskClientAboutPersNr();
                Member = MemberCatalog.getReferenceOfMemberInMemberCatalog(persNr);

                if (Member == null)
                {
                    VMemberDelete.NotExistingMember();
                    Menu.RenderingMenuDeleteMemberQuitOrContinueAndRememberClientsSelection();
                }
                if (Menu.selectedInMenuDeleteMember == V.MenuMemberDelete.Quit)
                {
                    break;
                }
            }
            return MemberCatalog.deleteMemberInMemberCatalog(Member);
        }
    }
}
