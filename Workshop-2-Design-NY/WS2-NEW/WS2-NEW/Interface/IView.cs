using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.Interface
{
    interface IView : ICRUD
    {
        void setRequest();

        string getResponse(string question = null, bool completelylOwnFormattedQuestion = false);

        void setCrudMessageToClient(Model.Cache.crudMode crudMode, Interface.IView view);

        void errorCrud(string errormessage);

        bool clientAnsweredYes(string cmd);

        bool clientSaidReturn(string cmd);
    }
}
