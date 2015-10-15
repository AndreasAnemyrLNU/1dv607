using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.Controller
{

    abstract class Menu : Controller, Interface.IMenu
    {
        protected Model.Cache.menuIndex SelectedInMenuIndex { get; set; }

        protected Model.Cache.menuBoat SelectedInMenuBoat { get; set; }

        protected Model.Cache.menuMember SelectedInMenuMember { get; set; }

        protected string ClientResponse { get; set; }

        public virtual void menuSwitcher(Interface.IView view, Interface.IController controller)
        {
            if (isCrudRequest(controller.Cache.getCrudModeInCache()))
            {
                // Requset crudMode != stateless
                switchCrudMessageToClient(controller.Cache.getCrudModeInCache(), view);
            }
            else
            {
                // Request crudMode == stateLess
                view.setRequest();
            }
        }

        public abstract override Model.Cache DoControl(Interface.IView view, Interface.IController controller);

        public Model.Cache prepareNewCacheFromMenuBoat()
        {
            switch (SelectedInMenuBoat)
            {
                case Model.Cache.menuBoat.Return:
                    return new Model.Cache(Model.Cache.controller.Boat, Model.Cache.view.Boat, Model.Cache.crudMode.Stateless, Cache.CachedBoatCatalog, Cache.CachedMemberCatalog);
                
                case Model.Cache.menuBoat.Create:
                    return new Model.Cache(Model.Cache.controller.Boat, Model.Cache.view.Boat, Model.Cache.crudMode.Create, Cache.CachedBoatCatalog, Cache.CachedMemberCatalog);
                
                case Model.Cache.menuBoat.Read:
                    return new Model.Cache(Model.Cache.controller.Boat, Model.Cache.view.Boat, Model.Cache.crudMode.Read, Cache.CachedBoatCatalog, Cache.CachedMemberCatalog);
                
                case Model.Cache.menuBoat.Update:
                    return new Model.Cache(Model.Cache.controller.Boat, Model.Cache.view.Boat, Model.Cache.crudMode.Update, Cache.CachedBoatCatalog, Cache.CachedMemberCatalog);
                
                case Model.Cache.menuBoat.Delete:
                    return new Model.Cache(Model.Cache.controller.Boat, Model.Cache.view.Boat, Model.Cache.crudMode.Delete, Cache.CachedBoatCatalog, Cache.CachedMemberCatalog);

                case Model.Cache.menuBoat.GoToMenuBoatCatalog:
                    throw new NotImplementedException();
                                    
                case Model.Cache.menuBoat.GoToMenuIndex :
                    return prepareNewCacheFromMenuIndex();

                default:
                    throw new NotImplementedException();
            }
        }

        public Model.Cache prepareNewCacheFromMenuIndex()
        {
            switch (SelectedInMenuIndex)
            {
                case Model.Cache.menuIndex.Boat :
                    return new Model.Cache(Model.Cache.controller.Boat, Model.Cache.view.Boat, Model.Cache.crudMode.Stateless, Cache.CachedBoatCatalog, Cache.CachedMemberCatalog);

                case Model.Cache.menuIndex.Member:
                    return new Model.Cache(Model.Cache.controller.Member, Model.Cache.view.Member, Model.Cache.crudMode.Stateless, Cache.CachedBoatCatalog, Cache.CachedMemberCatalog);

                default:
                    return Cache;
            }
        }

        public Model.Cache prepareNewCacheFromMenuMember()
        {
            switch (SelectedInMenuMember)
            {
                case Model.Cache.menuMember.Return:
                    return new Model.Cache(Model.Cache.controller.Member, Model.Cache.view.Member, Model.Cache.crudMode.Stateless, Cache.CachedBoatCatalog, Cache.CachedMemberCatalog);

                case Model.Cache.menuMember.Create:
                    return new Model.Cache(Model.Cache.controller.Member, Model.Cache.view.Member, Model.Cache.crudMode.Create, Cache.CachedBoatCatalog, Cache.CachedMemberCatalog);

                case Model.Cache.menuMember.Read:
                    return new Model.Cache(Model.Cache.controller.Member, Model.Cache.view.Member, Model.Cache.crudMode.Read, Cache.CachedBoatCatalog, Cache.CachedMemberCatalog);

                case Model.Cache.menuMember.Update:
                    return new Model.Cache(Model.Cache.controller.Member, Model.Cache.view.Member, Model.Cache.crudMode.Update, Cache.CachedBoatCatalog, Cache.CachedMemberCatalog);

                case Model.Cache.menuMember.Delete:
                    return new Model.Cache(Model.Cache.controller.Member, Model.Cache.view.Member, Model.Cache.crudMode.Delete, Cache.CachedBoatCatalog, Cache.CachedMemberCatalog);

                case Model.Cache.menuMember.GoToMenuMemberCatalog:
                    throw new NotImplementedException();

                case Model.Cache.menuMember.GoToMenuIndex:
                    return prepareNewCacheFromMenuIndex();

                default:
                    throw new NotImplementedException();
            }
        }

        protected bool isCrudRequest(Model.Cache.crudMode crudMode) 
        {
            return crudMode != Model.Cache.crudMode.Stateless;
        }

        protected void switchCrudMessageToClient(Model.Cache.crudMode crudMode, Interface.IView view) 
        {
            switch (crudMode)
            {
                case Model.Cache.crudMode.Create:
                    view.Create();
                break;
                
                case Model.Cache.crudMode.Read:
                    view.Read();
                break;

                case Model.Cache.crudMode.Update:
                    view.Update();
                break;
                
                case Model.Cache.crudMode.Delete:
                    view.Delete();
                break;

                default :
                    throw new ApplicationException("A non existing CRUD-functionality?");
            }
        }

        public bool clientAnsweredYes(string cmd)
        {
            try
            {
                switch (cmd)
                {
                    case "y": return true;
                    case "Y": return true;
                    case "n": return false;
                    case "N": return false;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine(View.menu.clientAnsweredYes);
            }
            return false;
        }
    }
}
