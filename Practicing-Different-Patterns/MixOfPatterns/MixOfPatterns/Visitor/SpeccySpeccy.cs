using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixOfPatterns.Visitor
{
    class SpeccySpeccy : Visitor
    {
        public void visit(Liquor liquorItem)
        {
            Console.Write("Keep quiet" + liquorItem.GetType().Attributes.ToString());
        }

        public void visit(Tobacco tobaccoItem)
        {
            Console.Write("Keep quiet" + tobaccoItem.GetType().Attributes.ToString());
        }

        public void visit(Necessity necessityItem)
        {
            Console.Write("Keep quiet" + necessityItem.GetType().Attributes.ToString());
        }
    }
}
