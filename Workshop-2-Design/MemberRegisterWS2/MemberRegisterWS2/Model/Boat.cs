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

        public M.Member Member { get; set; }

        public Boat(Dimension dim, M.Member member, BoatType type)
        {
            Dim = dim;
            Member = member;
            Type = type;
            Unique = new DateTime().ToString();
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Type, Dim.ToString());
        }
    }
}
