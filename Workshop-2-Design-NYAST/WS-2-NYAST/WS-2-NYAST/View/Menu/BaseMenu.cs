using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.View
{
    abstract class BaseMenu : View.IMenu
    {
        // Menu status
        public Model.Menu ModelMenu { get; set; }

        public enum Menu { };

        protected View.ConsoleIn Cin { get; set; }

        protected View.ConsoleOut Cout { get; set; }

        protected BaseMenu(View.ConsoleIn cin, View.ConsoleOut cout, Model.Menu menu) 
        {
            Cin = cin;
            Cout = cout;
            ModelMenu = menu;
        }

        public BaseMenu(){ /* Empty */ }

        // Needed in the foreach loop in render
        protected int counter;

        protected void Render(string title, Array selectables)
        {
            counter = 0;

            // Title of menu here!
            Cout.Print(title);      
            // Dynamic menu renders here!
            foreach (var select in selectables)
            {
                if (counter != 0)
                {
                    Cout.Print(string.Format("{0} {1}", select, counter));
                }
                counter++;
            }
        }

        public abstract void ShowIt(View.BaseMenu menu, List<View.IMenu> imenus);

        public virtual void ShowIt(View.BaseMenu menu, List<View.IMenu> imenus, string title, Array selectables) 
        {
            Render(title, selectables);
        }

        // Common Questions
        protected static readonly string Create = "Do you want't to create a {0}";
        protected static readonly string Read =   "Do you want't to read a {0}";
        protected static readonly string Update = "Do you want't to update a {0}";
        protected static readonly string Delete = "Do you want't to delete a {0}";
        


    }
}
