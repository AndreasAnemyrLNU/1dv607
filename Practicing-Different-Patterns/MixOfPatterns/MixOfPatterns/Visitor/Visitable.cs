using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixOfPatterns.Visitor
{
    interface Visitable
    {
        void accept(Visitor visitor);
    }
}
 