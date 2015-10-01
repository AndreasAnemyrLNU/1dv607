using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.View
{
    class MemberCreate : common
    {

        public string AskClientAboutFirstName()
        {
            return base.AskForInput("Please: Input Member's first name: ");
        }

        public string AskClientAboutLastName()
        {
            return base.AskForInput("Please: Input Member's last name: ");
        }

        public string AskClientAboutPersonalNumber()
        {
            return base.AskForInput("Please: Input Member's personal number: ");
        }
    }
}
