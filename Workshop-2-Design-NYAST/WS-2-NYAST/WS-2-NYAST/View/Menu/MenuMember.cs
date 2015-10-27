using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.View
{
    public class MenuMember : BaseMenu
    {
        public enum Menu { StateLess, Create, Read, Update, Delete, Compact, Verbose, Save, Quit }

        public Menu State { get; set; }

        public MenuMember() : base() { /*Empty*/ }

        public MenuMember(View.ConsoleIn cin, View.ConsoleOut cout, Model.Menu menu)
        : base(cin, cout, menu)
        {
            //Empty
        }

        public const string Title = "Menu->Member!";

        public override void ShowIt(View.BaseMenu menu, List<View.IMenu> imenus)
        {
            ShowIt(menu, imenus, Title, Enum.GetValues(typeof(Menu)));
        }

        public const string FAQwhatsFirstName = "What´s the firstname of member?";
        public const string FAQwhatsLastName = "What´s the lastname of member?";
        public const string FAQwhatsSSN = "What´s the SSN of member?";


    }
}
