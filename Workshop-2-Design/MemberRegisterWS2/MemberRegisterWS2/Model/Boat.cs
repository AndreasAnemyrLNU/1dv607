using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.Model
{
    public enum BoatType
    {
        Sailboat,
        Motorsailer,
        Kayak_Canoe,
        Other
    }

    class Boat
    {
        private BoatType Type { get; set; }

        private Dimension Dim { get; set; }

        private int Unique { get; set; }

        public Boat(Dimension dim, BoatType type = BoatType.Other)
        {
            Type = type;
            Dim = dim;
        }        
    }
}
