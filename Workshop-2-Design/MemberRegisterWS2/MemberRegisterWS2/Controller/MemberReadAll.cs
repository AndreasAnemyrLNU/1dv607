using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.Controller
{
    class MemberReadAll : baseController
    {
        public void getCompactMemberCatalog(Model.MemberCatalog memberCatalog, View.MemberCatalog view)
        {
            view.outputCompactMemberCatalog(memberCatalog);
        }

        public void getVerboseMemberCatalog(Model.MemberCatalog memberCatalog, View.MemberCatalog view) 
        {
            view.outputCompactMemberCatalog(memberCatalog);
        }        
    }
}
