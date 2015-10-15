using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Model
{
 
    public class Member
    {
        public string firstName;
        public string lastName;
        public string SSN;
        public Member() 
        {
            // Empty
        }

        public Member(string firstName, string lastName, string personalNumber) 
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalNumber = personalNumber;
        }
        public string FirstName 
        {
            get { return firstName; }
            set 
            {
                validateText(value, 3, 22);
                firstName = value;
            } 
        }
        public string LastName 
        {
            get { return lastName; }
            set
            {
                validateText(value, 3, 16);
                lastName = value;
            } 
        }
        public string PersonalNumber 
        {
            get { return SSN; }
            set
            {
                validateText(value, 11, 11);
                SSN = value;
            }  
        }
        public bool validateText(string value, int minChars, int maxChars)
        {
            if (string.IsNullOrEmpty(value)) 
            {
                throw new Exception("Plz! - enter something...");
            }
            if (value.Length < minChars || value.Length > maxChars)
            {
                throw new Exception(string.Format("Plz! - min {0} letters\nAnd max {1}", minChars, maxChars));
            }
            return true;
        }
        public override string ToString()
        {
            return string.Format("\n\nFirstname:{0,23}\nLastname:{1,24}\nPersNr: {2,25}\n", FirstName, LastName, PersonalNumber);    
        }
        public bool Equals(Member member)
        {
            return this.SSN == member.SSN;
        }
    }
}
