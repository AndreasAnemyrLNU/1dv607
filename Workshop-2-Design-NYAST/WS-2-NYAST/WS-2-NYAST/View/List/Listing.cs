using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.View
{
    class Listing
    {
        private int i;

        public void Compact(Model.MemberCatalog memberCatalog, View.ConsoleOut cout, View.ConsoleIn cin) 
        {
            foreach (Model.Member member in memberCatalog.members)
            {
                cout.Print("||********************************");
                cout.Print("||Compact*************************");
                cout.Print(string.Format("||Memberid{0}", member.Uid));
                cout.Print(member.PersonalNumber);
                cout.Print(member.FirstName);
                cout.Print(member.LastName);
                cout.Print(string.Format("|| Has {0} boat(s)", member.BoatCatalog.boats.Count));
                cout.Print("||********************************");
            }
        }


        public void Verbose(Model.MemberCatalog memberCatalog, View.ConsoleOut cout, View.ConsoleIn cin)
        {
            foreach (Model.Member member in memberCatalog.members)
            {
                cout.Print("||********************************");
                cout.Print("||Compact*************************");
                cout.Print(string.Format("||Memberid{0}", member.Uid));
                cout.Print(member.PersonalNumber);
                cout.Print(member.FirstName);
                cout.Print(member.LastName);
                foreach (Model.Boat boat in member.BoatCatalog) 
                {
                    cout.Print("||Boat****************************");
                    cout.Print(boat.Type.GetType().Name);
                    cout.Print(boat.Length.ToString());
                    cout.Print("||********************************");
                }
            }
        }

        public void ShowMember(Model.Member member, ConsoleOut cout, ConsoleIn cin) 
        {
            cout.Print("||********************************");
            cout.Print("||********************************");
            cout.Print(member.PersonalNumber);
            cout.Print(member.FirstName);
            cout.Print(member.LastName);    
            cout.Print("||********************************");
            cout.Print("||********************************");
        }

    
    }



}
