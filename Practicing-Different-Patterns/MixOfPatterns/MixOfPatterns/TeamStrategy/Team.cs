using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixOfPatterns.TeamStrategy
{
    public abstract class Team
    {

        public string teamName { get; set; }

        public TeamStrategy teamStrategy { get; set; }

        public abstract void teamInfo();

        public void PlayGame() 
        {
            teamStrategy.play(teamName);
        }
    }
}
