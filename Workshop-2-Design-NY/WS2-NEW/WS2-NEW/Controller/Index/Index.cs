using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.Controller
{
    class Index : Menu
    {
        public override void menuSwitcher(Interface.IView view, Interface.IController controller)
        {
            view.setRequest();
        }

        public override Model.Cache DoControl(Interface.IView view, Interface.IController controller)
        {
            menuSwitcher(view, controller);
            ClientResponse = view.getResponse();            
            SelectedInMenuIndex = (Model.Cache.menuIndex)int.Parse(ClientResponse);

            return prepareNewCacheFromMenuIndex();
        }
    }
}
