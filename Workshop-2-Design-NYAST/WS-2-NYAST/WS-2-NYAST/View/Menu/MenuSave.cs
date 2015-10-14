using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.View
{
    class MenuSave : BaseMenu
    {
        new public enum Menu { StateLess, Save, Quit }

        private Menu State { get; set; }

        public MenuSave(View.ConsoleIn cin, View.ConsoleOut cout, Model.Menu menu)
        : base(cin, cout, menu)
        {
            //Empty
        }

        private const string Title = "Menu->Save!";

        public override void ShowIt(View.BaseMenu menu, List<View.IMenu> imenus)
        {
            base.ShowIt(menu, imenus, Title, Enum.GetValues(typeof(Menu)));  
        }
    }
}
