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
    }
}
