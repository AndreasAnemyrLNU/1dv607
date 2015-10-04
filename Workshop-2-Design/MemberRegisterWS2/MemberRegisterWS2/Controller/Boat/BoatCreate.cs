using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.C
{
    class BoatCreate : BaseBoat
    {
        public M.Boat DoBoatCreate() 
        {
            M.Dimension dim = new M.Dimension(600, M.UnitOfMeasure.cm);

            M.Boat boat = new M.Boat(dim, M.BoatType.Kayak_Canoe, "unique");

            return boat;
        }
    }
}
