using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.M
{
    class BoatCatalog : IEnumerator, IEnumerable
    {
        private List<Boat> boats;

        //Needed for IEnumerator, IEnumerable
        public int position = -1;

        public BoatCatalog()
        {
            boats = new List<Boat>();
        }


        public M.Boat addBoat(Boat boat)
        {
            boats.Add(boat);
            return boat;
        }

        public M.Boat deleteBoatInBoatCatalog(M.Boat boatToBeDeleted) 
        {
            foreach(M.Boat boat in boats)
            {
                if (boat.Equals(boatToBeDeleted))
                {
                    boats.Remove(boat);
                    return boatToBeDeleted;
                }
            }
            return null;
        }

        //Needed for IEnumerator, IEnumerable
        public object Current
        {
            get { return boats[position]; }
        }

        //Needed for IEnumerator, IEnumerable
        public bool MoveNext()
        {
            position++;
            return (position < boats.Count);
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

        public List<Boat> getReferencesOfMemberBoatsInBoatCatalog(M.Member member)
        {
            // Local created BoatCatalog for currnet member       
            List<Boat> memberboats = new List<Boat>();

            foreach (M.Boat boat in boats) 
            {

                if (member.PersNr == boat.Member.PersNr) 
                {
                    memberboats.Add(boat);
                }
            }

            return memberboats;
        }
    }
}
