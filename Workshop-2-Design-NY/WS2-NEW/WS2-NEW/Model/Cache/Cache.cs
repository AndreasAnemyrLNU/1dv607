using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.Model
{
    class Cache
    {
        public Cache(controller controller, view view, crudMode crudMode = crudMode.Stateless, BoatCatalog boatCatalog = null, MemberCatalog memberCatalog = null) 
        {
            CachedController = controller;
            CachedView = view;
            CachedCrudMode = crudMode;
            CachedBoatCatalog = boatCatalog;
            CachedMemberCatalog = memberCatalog;

            if (boatCatalog == null) 
            {
                throw new ApplicationException("Where´s boatcatalog? Nothing to use in the Constructor...");
            }
            if (memberCatalog == null)
            {
                throw new ApplicationException("Where´s boatcatalog? Nothing to use in the Constructor...");
            }

        }

        private controller CachedController { get; set; }

        private view CachedView { get; set; }

        private crudMode CachedCrudMode { get; set; }

        public enum crudMode { Stateless, Create, Read, Update, Delete}

        public enum controller { Stateless, Index, Member, Boat }

        public enum view { Stateless, Index, Member, Boat }

        public enum menuIndex
        {
            Boat = 1,
            Member = 2,
            Save = 3,
            Quit = 4
        }

        public enum menuBoat
        {
            Return,
            Create = 1,
            Read = 2,
            Update = 3,
            Delete = 4,
            GoToMenuBoatCatalog = 5,
            GoToMenuIndex = 6
        }

        public enum menuMember
        {
            Quit,
            Create = 1,
            Read = 2,
            Update = 3,
            Delete = 4,
            GoToMenuBoatCatalog = 5,
            GoToMenuIndex = 6
        }

        public crudMode getCrudModeInCache() 
        {
            return CachedCrudMode;
        }

        public controller getControllerInCache()
        {
            return CachedController;
        }

        public view getViewInCache()
        {
            return CachedView;
        }

        public controller setControllerInCache(controller controllerToBeCached) 
        {
            CachedController = controllerToBeCached;
            return CachedController;
        }

        public crudMode setCrudModeInCache(crudMode crudModeToBeCached)
        {
            CachedCrudMode = crudModeToBeCached;
            return CachedCrudMode;
        }

        public view setViewInCache(view viewToBeCached)
        {
            CachedView = viewToBeCached;
            return CachedView;
        }

        // Catalogs to be cached...
        public MemberCatalog CachedMemberCatalog { get; set; }

        public BoatCatalog CachedBoatCatalog { get; set; }
    }
}
