using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS2_NEW.View
{
    abstract class Crud : WS2_NEW.View.View, Interface.ICRUD
    {
        override public abstract void setRequest();

        override public abstract string getResponse();

        public abstract void Create();

        public abstract void Read();

        public abstract void Update();

        public abstract void Delete();
    }
}
