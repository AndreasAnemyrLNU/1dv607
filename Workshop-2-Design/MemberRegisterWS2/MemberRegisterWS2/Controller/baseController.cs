using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.Controller
{
    class baseController
    {
        protected baseController ControllerFactory(string controllerToBeCreated)
        {
            switch (controllerToBeCreated)
            {
                
                case "MemberCreate":
                    return new Controller.MemberCreate();

                case "MemberReadAll":
                    return new Controller.MemberReadAll();
                
                default:
                    //controllerToBeCrated fails matching!
                    return null;
            }
        }
    }
}
