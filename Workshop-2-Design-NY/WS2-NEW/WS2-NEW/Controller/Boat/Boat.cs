using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.Controller
{
    class Boat : Menu
    {
        public override Model.Cache DoControl(Interface.IView view, Interface.IController controller)
        {
            if (controller.Cache.getCrudModeInCache() != Model.Cache.crudMode.Stateless)
            {
                // CRUD FUNCTIONALITY HERE
                switch (controller.Cache.getCrudModeInCache())
                {
                    case Model.Cache.crudMode.Create:
                        menuSwitcher(view, controller);

                        Model.Member member = new Model.Member
                                                            (
                                                                view.getResponse("Firstname"),
                                                                view.getResponse("Lastname"),
                                                                view.getResponse("Personal Number")
                                                            );
                                                                           

                        Console.WriteLine(member);
                        return null;

                    default:
                        throw new NotImplementedException();
                }
            }
            else 
            {
                menuSwitcher(view, controller);
                ClientResponse = view.getResponse();
                SelectedInMenuBoat = (Model.Cache.menuBoat)int.Parse(ClientResponse);
                return prepareNewCacheFromMenuBoat();
            }
        }
    }
}
