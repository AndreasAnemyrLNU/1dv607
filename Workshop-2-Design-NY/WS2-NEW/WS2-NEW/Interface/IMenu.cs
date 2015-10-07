using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.Interface
{
    interface IMenu
    {
        void RenderMenu(Interface.IView view, Interface.IController controller);
    }
}
