using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MixOfPatterns.Visitor
{
    public class Liquor : Visitable
    {

        public void accept(Visitor visitor)
        {
            visitor.visit(this);
            return;
        }
    }
}
