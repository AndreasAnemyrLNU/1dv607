using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.M
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
        public BoatType Type { get; set; }

        public Dimension Dim { get; set; }

        public string Unique { get; set; }

        public Boat(Dimension dim, BoatType type, string unique)
        {
            Dim = dim;
            Type = type;
            Unique = unique;
            
        }        
    }
}
