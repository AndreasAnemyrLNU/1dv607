using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixOfPatterns.strategy
{
    class Speaky2 : ISpeaky
    {
        public void WhatsYourName()
        {
            Console.Write("I did it as Speaky2 said I should!\n");
        } 
    }
}
