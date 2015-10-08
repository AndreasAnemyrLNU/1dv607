using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.Controller
{
    class Controller : Interface.IController
    {
        private Interface.IController CurrentController { get; set; }

        private Interface.IView CurrentView { get; set; }
        
        public Model.Cache Cache { get; set;}

        // Constructor
        public Controller() 
        {
            // Empty
        }

        public Interface.IController FactoryController(Model.Cache Cache)
        {
            switch (Cache.getControllerInCache()) 
            {
                
                case Model.Cache.controller.Boat:
                    CurrentController = new Boat() as Interface.IController;
                    // "Moving" cache to new controller Important!
                    CurrentController.Cache = Cache;
                    return CurrentController;
                
                case Model.Cache.controller.Index :
                    CurrentController = new Index() as Interface.IController;
                    // "Moving" cache to new controller Important!
                    CurrentController.Cache = Cache;
                    return CurrentController;

                case Model.Cache.controller.Member:
                    CurrentController = new Member() as Interface.IController;
                    // "Moving" cache to new controller Important!
                    CurrentController.Cache = Cache;
                    return CurrentController;

                case Model.Cache.controller.Stateless:
                    throw new NotImplementedException();
                    //CurrentController = new Stateless() as Interface.IController;
                    //return CurrentController;

                default:
                    return null;
            }     
        }

        public Interface.IView FactoryView(Model.Cache Cache)
        {
            switch (Cache.getViewInCache())
            {
                case Model.Cache.view.Boat:
                    CurrentView = new View.Boat() as Interface.IView;
                    return CurrentView;

                case Model.Cache.view.Index:
                    CurrentView = new View.Index() as Interface.IView;
                    return CurrentView;

                case Model.Cache.view.Member:
                    CurrentView = new View.Member() as Interface.IView;
                    return CurrentView;

                case Model.Cache.view.Stateless:
                    //CurrentView = new View.Stateless() as Interface.IView;
                    //return CurrentView;
                    throw new NotImplementedException();

                default:
                    return null;
            }
        }

        public void DoApplication()
        {
            
            // First time caching is set to "index" in Cache's constructor for both view and controller
            Cache = new Model.Cache(Model.Cache.controller.Index, Model.Cache.view.Index, Model.Cache.crudMode.Stateless, new Model.BoatCatalog(), new Model.MemberCatalog());    
        
            // Rember that cached catalogs can be lost if a new
            // controller has been created. Cache needs to be updated
            // before returning into the loop.... Important!
                      
            while(true)
            {
                // Appropirate controller needs to be created. This depend on Cache.getController()
                CurrentController = FactoryController(Cache);
                // Appropirate view needs to be created. This depend on Cache.getView()
                CurrentView = FactoryView(Cache);

                // Here´s the cool DoControl. It's Magic! :)      
                //Interfaces - Polymorphism - enums. They are all my best friend for now...
                Cache = CurrentController.DoControl(CurrentView, CurrentController);
            }   
        }

        public virtual Model.Cache DoControl(Interface.IView view, Interface.IController icontroller) 
        {
            throw new NotImplementedException();
        }
    }
}
