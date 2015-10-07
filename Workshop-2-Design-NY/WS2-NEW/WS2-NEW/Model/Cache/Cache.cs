using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.Model
{
    class Cache
    {
        public Cache(controller controller, view view) 
        {
            CachedController = controller;
            CachedView = view;
        }

        private controller CachedController { get; set; }

        private view CachedView { get; set; }

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
            Create = 1,
            Read = 2,
            Update = 3,
            Delete = 4,
            GoToMenuBoatCatalog = 5,
            GoTMenuIndex = 6
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

        public view setViewInCache(view viewToBeCached)
        {
            CachedView = viewToBeCached;
            return CachedView;
        }

    }
}
