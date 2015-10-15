using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WS_2_NYAST.Model
{
    public class MemberCatalog
    {
        // Counting boats per user to listr
        public int boatsCounter;

        public List<Member> members;

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

        public List<Member> Read()
        {
            return members;
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
            foreach (Model.Member _member in members) 
            {
                if (_member.PersonalNumber == member.PersonalNumber)
                {
                    throw new Exception(View.Error.ErroMessageAlreadyExistingMember);
                }
            }
            members.Add(member);
            return member;
        }

        //Needed for IEnumerator, IEnumerable
        public object Current
        {
            get { return members[_position]; }
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

        //Needed for IEnumerator, IEnumerable
        public int _position = -1;
        public int position;

        public List<Compact> Compact(Model.BoatCatalog boatCatalog) 
        {
            List<Compact> compacts = new List<Compact>(members.Count);

            foreach(Model.Member member in members)
            {
                foreach(Model.Boat boat in boatCatalog)
                {
                    if(boat.GroupId == member.PersonalNumber)
                        boatsCounter++;
                }
                compacts.Add(new Compact(member.SSN, member.FirstName, member.lastName, boatsCounter));
                boatsCounter = 0;
            }

            return compacts;
        }

        public List<Verbose> Verbose(Model.BoatCatalog boatCatalog)
        {
            List<Verbose> verboses = new List<Verbose>(members.Count);

            foreach (Model.Member member in members)
            {
                foreach (Model.Boat boat in boatCatalog)
                {
                    if (boat.GroupId == member.SSN) 
                    {
                        verboses.Add
                        (
                            new Verbose
                            (
                                member.SSN,
                                member.FirstName,
                                member.lastName,
                                boat.Length
                                //boat.Type
                            )   
                        );
                    }
                }
            }

            return verboses;
        }
    }
}
