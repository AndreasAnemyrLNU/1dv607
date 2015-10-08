using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.Controller
{
    class Member : Menu
    {
        public override Model.Cache DoControl(Interface.IView view, Interface.IController controller)
        {
            if (controller.Cache.getCrudModeInCache() != Model.Cache.crudMode.Stateless)
            {
                switch (controller.Cache.getCrudModeInCache())
                {
                // start region >>>>>
                // C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : 
                                                                                                                           //- - - - c r e a t e
                    case Model.Cache.crudMode.Create:
                        menuSwitcher(view, controller);
                        Model.Member member = new Model.Member();
                        // Validation for every objects field....
                        while (true)
                        {
                            try { member.FirstName = view.getResponse("Firstname"); break; }
                            catch (Exception e) { view.errorCrud(e.Message); }
                        }
                        while (true)
                        {
                            try { member.LastName = view.getResponse("Lastname"); break; }
                            catch (Exception e) { view.errorCrud(e.Message); }
                        }
                        while (true)
                        {
                            try { member.PersonalNumber = view.getResponse("Personal Number 11 chars\n(010203-0405)"); break; }
                            catch (Exception e) { view.errorCrud(e.Message); }
                        }
                        // Object was valid...
                        Console.WriteLine(member);
                        
                        // Client Answer questions send through method in view....
                        ClientResponse = view.getResponse("Is this correct? \nPress y or n \nand than press Enter \nYour current created Member \nwill than be cached in the tmp \ncatalog of Members...", true);

                        if (view.clientSaidYesBoxAllRight(ClientResponse)) 
                        {
                            Cache.CachedMemberCatalog.Create();
                            Cache.CachedMemberCatalog.AddMember(member);
                        }

                        Console.Write("och?");
                        Console.WriteLine(Cache.CachedMemberCatalog.Read(member));

                        Cache.setCrudModeInCache(Model.Cache.crudMode.Stateless);                                    
                        return Cache;
                    
                // C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : 
                                                                                                                           //- - - - - - r e a d
                    case Model.Cache.crudMode.Read:
                        
                        // Code here

                        Cache.setCrudModeInCache(Model.Cache.crudMode.Stateless);                                    
                        return Cache;

                // C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : :
                                                                                                                           // - - - -u p d a t e
                        case Model.Cache.crudMode.Update:
    
                    
                        // Code here

                        Cache.setCrudModeInCache(Model.Cache.crudMode.Stateless);
                        return Cache;
                // C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : 

                                                                                                                           //- - - - d e l e t e
                        case Model.Cache.crudMode.Delete:


                        // Code here

                        Cache.setCrudModeInCache(Model.Cache.crudMode.Stateless);
                        return Cache;
                // C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : : : C R U D : : : 
                // <<<<< end region
                    default:
                        throw new NotImplementedException();
                }
            }
            else 
            {
                menuSwitcher(view, controller);
                ClientResponse = view.getResponse();
                SelectedInMenuMember = (Model.Cache.menuMember)int.Parse(ClientResponse);
                return prepareNewCacheFromMenuMember();
            }
        }
    }
}
