using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.C
{
    class BoatCreate : BaseBoat
    {
        public M.Boat DoBoatCreate(M.Member member) 
        {            
            int length = new Random(100).Next(100,3000);
            M.BoatType boatType = (M.BoatType)new Random(100).Next(0, 4);

            M.Dimension dim = new M.Dimension(length, M.UnitOfMeasure.cm);
            M.Boat boat = new M.Boat(dim, member, M.BoatType.Kayak_Canoe);
            return boat;
        }
    }
}
