using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixOfPatterns.strategy
{
    class Speaky3 : ISpeaky
    {
        public void WhatsYourName()
        {
            Console.Write("Oh I'm speaky nr 3. I'm not a kund person\nI do not tell my name!. Hohohohoa!");
        }
    }
}
