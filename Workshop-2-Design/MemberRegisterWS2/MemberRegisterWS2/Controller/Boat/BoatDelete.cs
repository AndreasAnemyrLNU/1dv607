using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.C
{
    class BoatDelete : BaseBoat
    {

        private M.MemberCatalog MemberCatalog;

        private M.BoatCatalog BoatCatalog;

        private V.Index Menu;

        private List<M.Boat> Boats { get; set; }

        public BoatDelete(V.Index menu, M.MemberCatalog memberCatalog, M.BoatCatalog boatCatalog) 
        {
            BoatCatalog = boatCatalog;
            MemberCatalog = memberCatalog;
            Menu = menu;
            Boats = new List<M.Boat>();
        }

        public List<M.Boat> DoFetchBoatReferencesInBoatCatalg()
        {
            M.Member member = MemberCatalog.getReferenceOfMemberInMemberCatalog
            (Menu.AskForInput("First! Input personal number for owner of boat(s)"));
         
            foreach(M.Boat boat in BoatCatalog)
            {
                if(boat.Member.PersNr == member.PersNr)
                {
                    if (Menu.askClientBeforeDelete(boat.ToString())) 
                    {
                        Boats.Add(boat);
                    }
                }
            }
            return Boats;
        }
    }
}
