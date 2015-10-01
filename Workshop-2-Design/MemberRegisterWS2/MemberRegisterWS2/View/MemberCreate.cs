using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.View
{
    class MemberCreate : common
    {

        public string askClientAboutFirstName()
        {
            return base.askForInput("Please: Input First Name Of Member");
        }

        public string askClientAboutLastName()
        {
            throw new NotImplementedException();
        }

        public string askClientAboutPersonalNumber()
        {
            throw new NotImplementedException();
        }
    }
}
