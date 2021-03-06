﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.M
{
    class MemberCatalog : IEnumerator, IEnumerable
    { 
        private List<Member> members;

        //Needed for IEnumerator, IEnumerable
        public int position = -1;

        public MemberCatalog()
        {
            members = new List<Member>();
        }


        public M.Member addMember(Member member)
        {
            members.Add(member);
            return member;
        }

        public M.Member deleteMemberInMemberCatalog(M.Member memberToBeDeleted) 
        {
            foreach(M.Member member in members)
            {
                if (member.Equals(memberToBeDeleted))
                {
                    members.Remove(member);
                    return memberToBeDeleted;
                }
            }
            return null;
        }

        //Needed for IEnumerator, IEnumerable
        public object Current
        {
            get { return members[position]; }
        }

        //Needed for IEnumerator, IEnumerable
        public bool MoveNext()
        {
            position++;
            return (position < members.Count);
        }
        
        //Needed for IEnumerator, IEnumerable
        public void Reset()
        {
            { position = -1; }
        }

        //Needed for IEnumerator, IEnumerable
        public IEnumerator GetEnumerator() 
        {
            return (IEnumerator)this;
        }

        public M.Member getReferenceOfMemberInMemberCatalog(string persNr)
        {
            foreach (M.Member member in members) 
            {
                if (member.PersNr == persNr) 
                {
                    return member;
                }
            }
            return null;
        }
    }
}
