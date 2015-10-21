using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MixOfPatterns.Visitor
{
    public class Tobacco : Visitable
    {
        public void accept(Visitor visitor)
        {
            visitor.visit(this);
            return;
        }
    }
}
