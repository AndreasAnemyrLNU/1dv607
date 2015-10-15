using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Model
{
    public class Compact
    {
        public int BoatsTotal;
        public string SSN;
        public string Fname;
        public string Lname;
        
        public Compact(string ssn, string fname, string lname, int boatsTotal)
        {
            SSN = ssn;
            Fname = fname;
            Lname = lname;
            BoatsTotal = boatsTotal;
        }
    }
}
