using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.Interface
{
    interface IController
    {
        Model.Cache Cache { get; set; }

        IController FactoryController(Model.Cache vache);

        IView FactoryView(Model.Cache view);

        void DoApplication();

        Model.Cache DoControl(Interface.IView view, Interface.IController controller);
    }
}
