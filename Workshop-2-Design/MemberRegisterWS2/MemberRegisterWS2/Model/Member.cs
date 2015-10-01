using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.Model
{
    class Member
    {
        private string firstName;
       
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set 
            {
                if (false) 
                {
                    throw new Exception("Du måste skriva Andréas");
                }                
                firstName = value;
            }
        }


        private string lastName;

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (false)
                {
                    throw new Exception("Du måste skriva Anemyr");
                }
                lastName = value;
            }
        }


        public string PersNr { get; set; }

        public Member() 
        {
            //Empty
        }

        public Member(string name, string lastName, string persNr = "000000-0000")
        {
            FirstName = name;
            LastName = lastName;
            PersNr = persNr;
        }
    }
}
