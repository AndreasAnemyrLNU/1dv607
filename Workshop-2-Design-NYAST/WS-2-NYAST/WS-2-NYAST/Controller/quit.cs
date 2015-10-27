using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Controller
{
    class Quit : Index
    {
        public Quit (Controller.Index index)
        : base(index) { /*empty*/ }


                //public void JustDoIt(View.ConsoleIn cin, View.ConsoleOut cout, int millis, Model.Menu menuMain)


        public void JustDoIt(int millis, Controller.Index index)
        {
                Cout.Print(string.Format(View.ConsoleIn.FAQQuitMessage, millis));
                System.Threading.Thread.Sleep(millis);
                MenuMain.State = Model.Menu.MainMenu.StateLess;    
        }
    }
}
