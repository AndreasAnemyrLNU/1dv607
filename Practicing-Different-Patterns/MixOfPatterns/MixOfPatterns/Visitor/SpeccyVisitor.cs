using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixOfPatterns.Visitor
{
    class SpeccyVisitor : Visitor
    {
        public void visit(Liquor liquorItem)
        {
            Console.WriteLine("This is Liquor::Visitor::SpeccyVisitor");
        }

        public void visit(Tobacco tobaccoItem)
        {
            Console.WriteLine("This is Tobacco::Visitor::SpeccyVisitor");
        }

        public void visit(Necessity necessityItem)
        {
            Console.WriteLine("This is Necessity::Visitor::SpeccyVisitor");
        }
    }
}
