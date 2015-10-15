using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.View
{
    class Listings
    {
        private int i;

        public void Compacts(List<Model.Compact> compacts, View.ConsoleOut cout, View.ConsoleIn cin) 
        {
            i = 0;
            foreach(Model.Compact compact in compacts)
            {
                cout.Print("||********************************");
                cout.Print("||********************************");
  cout.Print(string.Format("||********************NR: {0}", i  ));
                cout.Print(compact.SSN);
                cout.Print(compact.Fname);
                cout.Print(compact.Lname);                
 cout.Print(string.Format("This member has {0} boats :)",compact.BoatsTotal.ToString()));
               cout.Print("||********************************");


               if (cin.boolResponseOfQuestion("(y) Return to Menumember...", "yY")) 
               {
                   return;
               }

            }
        }


        public void Verboses(List<Model.Verbose> verboses, ConsoleOut cout, ConsoleIn cin)
        {
            i = 0;
            foreach (Model.Verbose verbose in verboses)
            {
                cout.Print("||********************************");
                cout.Print("||Verbose*************************");
                cout.Print(verbose.SSN);
                cout.Print(verbose.Fname);
                cout.Print(verbose.Lname);
                //cout.Print(verbose.Type.GetType().Name);
                cout.Print(string.Format("This boat's length: {0} cm", verbose.Length));
                cout.Print("||********************************");


                if (cin.boolResponseOfQuestion("(y) Return to Menumember...", "yY"))
                {
                    return;
                }

            }
            
        }
    }
}
