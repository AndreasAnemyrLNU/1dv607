using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixOfPatterns.Visitor
{
    public interface Visitor
    {

        //Here´s the Visitor interface
        //and it uses
        //Method overloading for different incoming

        void visit(Liquor liquorItem);

        void visit(Tobacco tobaccoItem);

        void visit(Necessity necessityItem);
    }
}
