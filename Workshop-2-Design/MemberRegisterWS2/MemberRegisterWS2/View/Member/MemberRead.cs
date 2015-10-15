using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.V
{
    enum MenuMemberRead
    {
        Quit = 0,
        Continue = 1,
        MemberRead = 2,
        AddBoatToMember = 3,
        StatelessForNow
    }

    class MemberRead : baseMember
    {
        public string AskClientAboutPersonalNumber()
        {
            return base.AskForInput("Please: Input Member's Personal Number: ");
        }

        public void NotExistingMember()
        {
            Console.WriteLine("Member does not exist!");
        }
    }
}

