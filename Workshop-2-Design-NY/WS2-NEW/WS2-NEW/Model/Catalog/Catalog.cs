using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.Model.Catalog
{
    abstract class Catalog : WS2_NEW.Model.Model, Interface.ICRUD 
    {
        abstract public void Create();

        abstract public void Read();

        abstract public void Update();

        abstract public void Delete();

        //TODO this is specific to view. Do not use!!!!!!
        public string AskForParameterToObject(string clientAnswered)
        {
            throw new NotImplementedException();
        }

        public Member AddMember(Member member)
        {
            throw new NotImplementedException();
        }

        public Member Read(Member toBeRead)
        {
            throw new NotImplementedException();
        }

        public Member Update(Member toBeUpdated)
        {
            throw new NotImplementedException();
        }

        public Member Delete(Member toBeDeleted)
        {
            throw new NotImplementedException();
        }
    }
}
