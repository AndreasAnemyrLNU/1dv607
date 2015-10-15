using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.V
{

    enum MenuMemberDelete
    {
        Quit = 0,
        Continue = 1,
        StatelessForNow
    }

    class MemberDelete : baseMember
    {
        public string AskClientAboutPersNr()
        {
            return base.AskForInput("Please: Input Member's Personal Number: ");
        }

        public void NotExistingMember()
        {
            Console.WriteLine("Member does not exist!");
        }
    }
}
