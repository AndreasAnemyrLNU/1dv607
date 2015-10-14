using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.View
{
    class MenuMain : BaseMenu
    {
        new public enum Menu { StateLess, Main, Member, Boat, Save, Quit }

        private Menu State { get; set; }

        public MenuMain(View.ConsoleIn cin, View.ConsoleOut cout, Model.Menu menu)
            : base(cin, cout, menu)
        {
            //Empty
        }

        private View.ConsoleIn In { get; set; }
        private View.ConsoleOut Out { get; set; }

        private const string Title = "Menu->Main!";

        public override void ShowIt(View.BaseMenu menu, List<View.IMenu> imenus)
        {
            ShowIt(menu, imenus, Title, Enum.GetValues(typeof(Menu)));
        }
    }
}
