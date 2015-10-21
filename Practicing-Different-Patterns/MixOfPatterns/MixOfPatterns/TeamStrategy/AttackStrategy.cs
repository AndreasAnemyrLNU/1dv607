using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixOfPatterns.TeamStrategy
{
    class AttackStrategy : TeamStrategy
    {
        public void play(string team)
        {
            Console.WriteLine(team + "will play in atacking mode");    
        }
    }
}
