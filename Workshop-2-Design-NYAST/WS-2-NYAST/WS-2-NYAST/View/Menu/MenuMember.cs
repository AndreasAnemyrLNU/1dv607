using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.View
{
    public class MenuMember : BaseMenu
    {
        new public enum Menu { StateLess, Create, Read, Update, Delete, Compact, Verbose, Save, Quit }

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

        // TODO Refactor this...
        /*public void ClientUpdatesStateForMenu(int input)
        {
            switch ((Menu)(input))
	        {
		        case Menu.StateLess:
                    State = Menu.StateLess;
                    break;
                case Menu.Create:
                    State = Menu.Create;
                    break;
                case Menu.Read:
                 State = Menu.Read;
                    break;
                case Menu.Update:
                    State = Menu.Update;
                    break;
                case Menu.Delete:
                    State = Menu.Delete;
                    break;
                case Menu.Save:
                    State = Menu.Save;
                    break;
                case Menu.Quit:
                    State = Menu.Quit;
                    break;
                default:
                    throw new ApplicationException("Something weird in menu happened!");
	        }
        }*/

        public const string FAQwhatsFirstName = "What´s the firstname of member?";
        public const string FAQwhatsLastName = "What´s the lastname of member?";
        public const string FAQwhatsSSN = "What´s the SSN of member?";


    }
}
