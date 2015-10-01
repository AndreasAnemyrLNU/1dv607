using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.Model
{
    class Member
    {
        private string name;
       
        public string Name
        {
            get
            {
                return name;
            }
            set 
            {
                if (value != "asdf") 
                {
                    throw new Exception("asdf");
                }                
                name = value;
            }
        }
   

        public string PersNr { get; set; }

        public Member() 
        {
            //Empty
        }

        public Member(string name, string persNr)
        {
            Name = name;
            PersNr = persNr;
        }
    }
}
