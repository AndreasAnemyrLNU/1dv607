using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.Interface
{
    interface ICRUD
    {
        void Create();

        void Read();

        void Update();

        void Delete();

        // Regsion Start For MemberCatalog!
        Model.Member Read(Model.Member toBeRead);

        Model.Member Update(Model.Member toBeUpdated);

        Model.Member Delete(Model.Member toBeDeleted);

        Model.Member AddMember(Model.Member member); 
        // Regions End For MemberCatalog
    }
}
