﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MixOfPatterns.Visitor
{
    public class Necessity : Visitable
    {
        public void accept(Visitor visitor)
        {
            visitor.visit(this);
            return;
        }
    }
}
