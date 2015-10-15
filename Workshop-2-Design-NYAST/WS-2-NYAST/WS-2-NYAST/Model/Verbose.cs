using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Model
{
    public class Verbose
    {
        //public Model.Boat.TypeBoat Type;
        public int Length;
        public string SSN;
        public string Fname;
        public string Lname;
        
        public Verbose
        (
            string ssn, 
            string fname,
            string lname, 
            int length 
            //Model.Boat.TypeBoat type
        )
        {
            Length = length;
            SSN = ssn;
            Fname = fname;
            Lname = lname;
            //Type = type;
        }
    }
}
