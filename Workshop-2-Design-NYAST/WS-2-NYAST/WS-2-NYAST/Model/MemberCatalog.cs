using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_2_NYAST.Model
{
    class MemberCatalog
    {
        private List<Member> members;

        public MemberCatalog()
        {
            // Empty
        }

        public void Create()
        {
            members = new List<Member>();

            if (members == null)
            {
                throw new Exception("Fail: The Catalog of members could not be created!");
            }
        }

        public Member Read(Member toBeRead)
        {
            foreach (Member member in members)
            {
                member.Equals(toBeRead);
                return member;
            }
            return null;
        }

        public Member Read(string SSN)
        {
            foreach (Member member in members)
            {
                if (SSN.Equals(member.PersonalNumber))
                {
                    return member;
                }
            }
            return null;
        }

        public Member Update(Member toBeUpdated)
        {
            foreach (Member member in members)
            {
                member.Equals(toBeUpdated);
                return toBeUpdated;
            }
            return null;
        }

        public Member Delete(Member toBeDeleted)
        {                        
                foreach (Member member in members)
                {
                    member.Equals(toBeDeleted);
                    members.Remove(toBeDeleted);
                    if(members.Count == 0)
                        break;
                }
            return toBeDeleted;            
        }

        public Member AddMember(Member member)
        {
            members.Add(member);
            return member;
        }
    }
}
