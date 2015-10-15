using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegisterWS2.C
{

    // ControllerType is CType
    public enum CType
    {
        MemberCreate,
        MemberRead,
        MemberReadAll,
        MemberUpdate,
        MemberDelete,
        BoatCreate,
        BoatRead,
        BoatReadAll,
        BoatUpdate,
        BoatDelete
    }
    
    class BaseController
    {                
        protected BaseController CFactory
                                            (
                                                CType cType, V.Index menu = null, 
                                                M.MemberCatalog memberCatalog = null, 
                                                M.Member member = null, 
                                                M.BoatCatalog boatCatalog = null
                                            )
        {
            switch (cType)
            {
                
                case CType.MemberCreate :
                    return new C.MemberCreate();

                case CType.MemberRead:
                    return new C.MemberRead(memberCatalog, menu, boatCatalog);

                case CType.MemberReadAll :
                    return new C.MemberReadAll(menu);

                case CType.MemberUpdate :
                    return new C.MemberUpdate(memberCatalog, member, menu);

                case  CType.MemberDelete :
                    return new C.MemberDelete(memberCatalog, menu);

                case CType.BoatCreate:
                    return new C.BoatCreate();

                case CType.BoatDelete:
                    return new C.BoatDelete(menu, memberCatalog, boatCatalog);

                default:
                    //controllerToBeCrated fails matching!
                    return null;
            }
        }
    }
}
