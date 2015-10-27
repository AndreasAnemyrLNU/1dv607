using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.View
{
    public class MenuBoat : BaseMenu
    {
        public enum Menu { StateLess, Create, Read, Update, Delete, Save, Quit}

        public Menu State { get; set; }

        public MenuBoat(View.ConsoleIn cin, View.ConsoleOut cout, Model.Menu menu)
        : base(cin, cout, menu)
        {
            //Empty
        }

        private const string Title = "Menu->Boat!";

        public override void ShowIt(View.BaseMenu menu, List<View.IMenu> imenus)
        {
            base.ShowIt(menu, imenus, Title, Enum.GetValues(typeof(Menu))); 
        }
    }
}
