using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Controller
{
    class quit
    {
        public void JustDoIt(View.ConsoleIn cin, View.ConsoleOut cout, int millis, Model.Menu menuMain)
        {
                cout.Print(string.Format(View.ConsoleIn.FAQQuitMessage, millis));
                System.Threading.Thread.Sleep(millis);
                menuMain.State = Model.Menu.MainMenu.StateLess;
       
        }
    }
}
