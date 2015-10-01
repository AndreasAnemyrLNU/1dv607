using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.Model
{
    class MemberCatalog : IEnumerator, IEnumerable
    { 
        public List<Member> members;

        //Needed for IEnumerator, IEnumerable
        public int position;

        public MemberCatalog()
        {
            members = new List<Member>();
        }


        public void addMember(Member member)
        {
            members.Add(member);
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
            { position = 0; }
        }

        //Needed for IEnumerator, IEnumerable
        public IEnumerator GetEnumerator() 
        {
            return (IEnumerator)this;
        }
    }
}
