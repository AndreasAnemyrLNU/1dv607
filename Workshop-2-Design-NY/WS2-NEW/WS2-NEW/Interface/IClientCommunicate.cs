using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.Interface
{
    interface IClientCommunicate
    {

        void setRequest();

        string getResponse(string Question = null, bool completelylOwnFormattedQuestion = false);
    }
}
