using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.M
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

        private string persNr;

        public string PersNr 
        {
            get 
            {
                return persNr;
            } 
            set
            {
                if (value.Count() != 11) 
                {
                    throw new Exception("Input format should be xxxxxx-xxxx");
                }

                persNr = value;
            } 
        }

        public Member() 
        {
            //Empty
        }

        public Member(string name, string lastName, string persNr = "xxxxxx-xxxx")
        {
            FirstName = name;
            LastName = lastName;
            PersNr = persNr;
        }

        public override string ToString()
        {
            return string.Format("> Personal Number: {0}\n> Firstname:       {1}\n> Lastname:        {2}",PersNr, FirstName, LastName);
        }
    }
}
